using Microsoft.EntityFrameworkCore;
using SedmiProjekt.Models;

namespace SedmiProjekt.Models
{
    public class RepozitorijUpiti : IRepozitorijUpiti
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpiti(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Albumi albumi)
        {
            _appDbContext.Add(albumi);
            _appDbContext.SaveChanges();
        }

        public void Create(Zanr zanr)
        {
            _appDbContext.Add(zanr);
            _appDbContext.SaveChanges();
        }

        public void Delete(Albumi albumi)
        {
            _appDbContext.Albumi.Remove(albumi);
            _appDbContext.SaveChanges();
        }

        public void Delete(Zanr zanr)
        {
            _appDbContext.Zanr.Remove(zanr);
            _appDbContext.SaveChanges();
        }

        public Albumi DohvatiAlbumSIdom(int id)
        {
            return _appDbContext.Albumi
                .Include(k => k.Zanr)
                .FirstOrDefault(f => f.Id == id);
        }

        public Zanr DohvatiZanrSIdom(int id)
        {
            return _appDbContext.Zanr.Find(id);
        }

        public int ZanrSljedeciId()
        {
            int zadnjiId = _appDbContext.Zanr
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Albumi> PopisAlbuma()
        {

            return _appDbContext.Albumi.Include(k => k.Zanr);
        }

        public IEnumerable<Zanr> PopisZanrova()
        {
            return _appDbContext.Zanr;
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Albumi
                .Include(k => k.Zanr)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Albumi albumi)
        {
            _appDbContext.Albumi.Update(albumi);
            _appDbContext.SaveChanges();
        }

        public void Update(Zanr zanr)
        {
            _appDbContext.Zanr.Update(zanr);
            _appDbContext.SaveChanges();
        }

        public Albumi DohvatiAlbumSaIdom(int id)
        {
            return _appDbContext.Albumi.Where(k => k.Id == id).FirstOrDefault();
        }

        public Zanr DohvatiZanrSaIdom(int id)
        {
            return _appDbContext.Zanr.Where(k => k.Id == id).FirstOrDefault();
        }
    }
}
