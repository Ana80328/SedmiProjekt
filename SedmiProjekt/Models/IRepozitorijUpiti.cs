namespace SedmiProjekt.Models
{
    public interface IRepozitorijUpiti
    {
        IEnumerable<Albumi> PopisAlbuma();
        void Create(Albumi albumi); 
        void Delete(Albumi albumi);
        void Update(Albumi albumi);
        int SljedeciId();
        int ZanrSljedeciId();
        Albumi DohvatiAlbumSaIdom(int id);
        IEnumerable<Zanr> PopisZanrova();
        void Create(Zanr zanr);
        void Delete(Zanr zanr);
        void Update(Zanr zanr);
        Zanr DohvatiZanrSaIdom(int id);
    }
}
