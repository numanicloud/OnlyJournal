using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlyJournal.Data.Journal
{
	public class DirectoryJournalRepository : IJournalRepository
	{
		private readonly string dirPath;

		public DirectoryJournalRepository(string dirPath)
		{
			this.dirPath = dirPath;
		}

		public Journal Get(string key)
		{
			if (!Directory.Exists(dirPath))
			{
				throw new DirectoryNotFoundException($"ジャーナル データ用のルートディレクトリ {dirPath} が見つかりませんでした。");
			}

			var journalPath = Path.Combine(dirPath, key);
			if (!Directory.Exists(journalPath))
			{
				throw new DirectoryNotFoundException($"ジャーナル データ用ディレクトリ {journalPath} が見つかりませんでした。");
			}

			var fileName = Directory.EnumerateFiles(journalPath)
				.FirstOrDefault(x => Path.GetExtension(x) == ".md");
			if (fileName is null)
			{
				throw new FileNotFoundException($"ジャーナル ドキュメントとして有効なファイルが見つかりませんでした。");
			}
			else
			{
				using var file = new StreamReader(Path.Combine(journalPath, fileName));
				return new Journal { Markdown = file.ReadToEnd() };
			}
		}

		public JournalArticle[] GetAllArticles()
		{
			if (!Directory.Exists(dirPath))
			{
				throw new DirectoryNotFoundException($"ジャーナル データ用のルートディレクトリ {dirPath} が見つかりませんでした。");
			}

			return Directory.EnumerateDirectories(dirPath)
				.Select(x => new JournalArticle(x) { Priority = 1000 })
				.ToArray();
		}
	}
}
