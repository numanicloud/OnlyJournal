using Microsoft.EntityFrameworkCore;
using OnlyJournal.Data.Journal;
using OnlyJournalPage.Data;
using OnlyJournalPage.Data.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlyJournalPage.Model.Article
{
	public class JournalTypeInfo : ArticleTypeInfo<Journal>
	{
		public JournalTypeInfo() : base(4, ArticleType.Journal, "/Journal", 15000)
		{
		}

		protected override DbSet<Journal> GetDB(OnlyJournalContext context) => context.Journal;

		protected override int SelectId(Journal entity) => entity.Id;

		protected override object SelectOrderKey(Journal entity) => entity.TimeCreated;
	}
}
