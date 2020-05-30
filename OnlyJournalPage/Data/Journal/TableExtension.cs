using HeyRed.MarkdownSharp;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlyJournal.Data.Journal
{
	public class TableExtension : IMarkdownExtension
	{
		class TagScope : IDisposable
		{
			private readonly string tagName;
			private readonly StringBuilder builder;

			public TagScope(string tagName, StringBuilder builder, string attributes = "")
			{
				this.tagName = tagName;
				this.builder = builder;

				builder.AppendLine($"<{tagName} {attributes}>");
			}

			public void Dispose()
			{
				builder.AppendLine($"</{tagName}>");
			}
		}

		class HtmlBuilder
		{
			private StringBuilder builder;

			public HtmlBuilder()
			{
				builder = new StringBuilder();
			}

			public TagScope MakeScope(string tagName, string attributes = "")
				=> new TagScope(tagName, builder, attributes);

			public StringBuilder AppendLine(string text) => builder.AppendLine(text);

			public override string ToString() => builder.ToString();
		}

		public string Transform(string text)
		{
			var regex = new Regex(@"(\|(?<header>.+?))+\|\r?\n(\|-+)+\|\r?\n(?<row>(\|.+)+\|\r?\n)*(?<row>(\|.+)+\|)");
			var rowRegex = new Regex(@"(\|(?<field>.+?))+\|");
			var matches = regex.Matches(text);

			var result = text;

			foreach (Match match in matches)
			{
				var builder = new HtmlBuilder();

				var tableTag = builder.MakeScope("table", "class='table'");

				{
					using var theadTag = builder.MakeScope("thead");
					using var trTag = builder.MakeScope("tr");

					var headers = match.Groups["header"].Captures;
					foreach (Capture header in headers)
					{
						builder.AppendLine($"<th>{header}</th>");
					}
				}

				{
					using var tbodyTag = builder.MakeScope("tbody");

					var rows = match.Groups["row"].Captures;
					foreach (Capture row in rows)
					{
						using var trTag = builder.MakeScope("tr");

						var rowMatche = rowRegex.Match(row.Value);
						var fields = rowMatche.Groups["field"].Captures;
						foreach (Capture field in fields)
						{
							builder.AppendLine($"<td>{field.Value}</td>");
						}
					}
				}

				tableTag.Dispose();
				result = regex.Replace(result, builder.ToString());
			}

			return result;
		}
	}
}
