using MandrilAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System.Threading.Tasks;

namespace MandrilAPI.Models.Service
{
    public class RepositoryQueryMandrilHabilidades(MandrilContext context, ILogger<RepositoryQueryMandrilHabilidades> logger) : IRepositoryQueryMandrilHabilidades
    {
        protected readonly MandrilContext _contextDb = context;
        private ILogger<RepositoryQueryMandrilHabilidades> _logger = logger;
        public Habilidad SelectOneHabilidadesFromDb(int targetIdHabilidad)
        {
     
           //testar
            var query = _contextDb.Habilidades.FirstOrDefault((h => h.id == targetIdHabilidad));
            if (query != null)
            {
                return  query;
            }
            else {
              _logger.LogWarning(DefaultsUserMessage.habilidadNotFound, query);
                return null;
                  }
            
        }

        public Mandril SelectOneMandrilsFromDb(int targetIdMandril)
        {
            //testar
           
               var mandril = _contextDb.Mandrils.FirstOrDefault((m => m.id == targetIdMandril));
            if (mandril is null)
            {
                _logger.LogWarning(DefaultsUserMessage.mandrilNotFound);
                return  null;
            }
                return  mandril;
        }

        public List<Mandril> SelectAllMandrilsFromDb()
        {
            var MandrilesInDb = _contextDb.Mandrils.ToList();

            if (MandrilesInDb.Count is 0)
            {
               
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return MandrilesInDb;
            }    
        return MandrilesInDb;
            
        }

        public  MandrilHabilidades SelectMandrilWithHabilidadesFromDb(int targetIdMandril, int targetIdHabilidad)
        {
            var query =_contextDb.MandrilHabilidades.Include(m => m.Mandril.id == targetIdMandril).Include(h => h.Habilidad.id == targetIdHabilidad).First();

            return query ;
        }
    

    
        
        
    }
}
