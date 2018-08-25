using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktDesktop
{
    public class DataAccessClass
    {
        public dtsAllesTableAdapters.AanvraagsTableAdapter AanvragenTA;
        public dtsAllesTableAdapters.ActeurFilmsTableAdapter ActeursFilmsTA;
        public dtsAllesTableAdapters.ActeurSeriesTableAdapter ActeursSeriesTA;
        public dtsAllesTableAdapters.ActeursTableAdapter ActeursTA;
        public dtsAllesTableAdapters.AfleveringArchiefsTableAdapter AfleveringenArchiefTA;
        public dtsAllesTableAdapters.AfleveringsTableAdapter AfleveringenTA;
        public dtsAllesTableAdapters.ArchiefsTableAdapter ArchiefTA;
        public dtsAllesTableAdapters.CollectiesTableAdapter CollectiesTA;
        public dtsAllesTableAdapters.FilmArchiefsTableAdapter FilmsArchiefTA;
        public dtsAllesTableAdapters.FilmsTableAdapter FilmsTA;
        public dtsAllesTableAdapters.FilmTagsTableAdapter FilmTagsTA;
        public dtsAllesTableAdapters.GebruikerArchiefsTableAdapter GebruikersArchiefTA;
        public dtsAllesTableAdapters.GebruikersTableAdapter GebruikersTA;
        public dtsAllesTableAdapters.GemeentesTableAdapter GemeentesTA;
        public dtsAllesTableAdapters.SeriesTableAdapter SeriesTA;
        public dtsAllesTableAdapters.TagsTableAdapter TagsTA;
        
        public dtsAlles VulAdapters(System.ComponentModel.BackgroundWorker backgroundWorker, dtsAlles dts)
        {
            backgroundWorker.ReportProgress(0, "Aanvragen");
            AanvragenTA = new dtsAllesTableAdapters.AanvraagsTableAdapter();
            AanvragenTA.Fill(dts.Aanvraags);

            backgroundWorker.ReportProgress(1, "Alle Acteurs");
            ActeursFilmsTA = new dtsAllesTableAdapters.ActeurFilmsTableAdapter();
            ActeursFilmsTA.Fill(dts.ActeurFilms);
            
            ActeursSeriesTA = new dtsAllesTableAdapters.ActeurSeriesTableAdapter();
            ActeursSeriesTA.Fill(dts.ActeurSeries);

            ActeursTA = new dtsAllesTableAdapters.ActeursTableAdapter();
            ActeursTA.Fill(dts.Acteurs);

            backgroundWorker.ReportProgress(2, "Series");
            SeriesTA = new dtsAllesTableAdapters.SeriesTableAdapter();
            SeriesTA.Fill(dts.Series);

            backgroundWorker.ReportProgress(3, "Afleveringen");
            AfleveringenTA = new dtsAllesTableAdapters.AfleveringsTableAdapter();
            AfleveringenTA.Fill(dts.Afleverings);

            AfleveringenArchiefTA = new dtsAllesTableAdapters.AfleveringArchiefsTableAdapter();
            AfleveringenArchiefTA.Fill(dts.AfleveringArchiefs);

            backgroundWorker.ReportProgress(4, "Films");
            FilmsTA = new dtsAllesTableAdapters.FilmsTableAdapter();
            FilmsTA.Fill(dts.Films);

            FilmsArchiefTA = new dtsAllesTableAdapters.FilmArchiefsTableAdapter();
            FilmsArchiefTA.Fill(dts.FilmArchiefs);

            FilmTagsTA = new dtsAllesTableAdapters.FilmTagsTableAdapter();
            FilmTagsTA.Fill(dts.FilmTags);

            TagsTA = new dtsAllesTableAdapters.TagsTableAdapter();
            TagsTA.Fill(dts.Tags);

            backgroundWorker.ReportProgress(5, "Collecties");
            CollectiesTA = new dtsAllesTableAdapters.CollectiesTableAdapter();
            CollectiesTA.Fill(dts.Collecties);

            backgroundWorker.ReportProgress(6, "Gebruikers");
            GebruikersTA = new dtsAllesTableAdapters.GebruikersTableAdapter();
            GebruikersTA.Fill(dts.Gebruikers);

            GebruikersArchiefTA = new dtsAllesTableAdapters.GebruikerArchiefsTableAdapter();
            GebruikersArchiefTA.Fill(dts.GebruikerArchiefs);

            GemeentesTA = new dtsAllesTableAdapters.GemeentesTableAdapter();
            GemeentesTA.Fill(dts.Gemeentes);

            ArchiefTA = new dtsAllesTableAdapters.ArchiefsTableAdapter();
            ArchiefTA.Fill(dts.Archiefs);

            return dts;
        }
    }
}
