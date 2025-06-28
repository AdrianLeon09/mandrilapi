using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System.Collections.Immutable;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace MandrilAPI.Service
{
    public class MandrilSkillsReadRepository(MandrilDbContext contextDb, ILogger<MandrilSkillsReadRepository> logger) : IMandrilAndSkillsReadRepository
    {
        protected readonly MandrilDbContext _contextDb = contextDb;
        private ILogger<MandrilSkillsReadRepository> _logger = logger;
        public IReadOnlyList<Skill> GetOneHabilidadesFromDb(int targetHabilidadId)
        {
            
            //testar
            var HabilidadInDb = _contextDb.Skills.Where(h => h.id == targetHabilidadId).AsNoTracking().ToList();
            if (HabilidadInDb.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageUsers.habilidadNotFound, HabilidadInDb);
                
                return HabilidadInDb;
            }
            else {
               
                return HabilidadInDb;
            }

        }
        public IReadOnlyList<Skill> GetAllHabilidadesFromDb()
        {

            //testar
            var HabilidadesInDb = _contextDb.Skills.AsNoTracking().ToList();
            if (HabilidadesInDb.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageUsers.habilidadNotFound, HabilidadesInDb);

                return HabilidadesInDb;

            } else return HabilidadesInDb;
        }



        public IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId)
        {
            //testar

            var MandrilInDb = _contextDb.Mandrils.Where(m => m.id == targetMandrilId).AsNoTracking().ToList();
            if (MandrilInDb.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return MandrilInDb;
            }
            return MandrilInDb;
        }

        public IReadOnlyList<Mandril> GetAllMandrilsFromDb()
        {
            var MandrilesInDb = _contextDb.Mandrils.AsNoTracking().ToList();

            if (MandrilesInDb.Count is 0)
            {

                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return MandrilesInDb;
            }
            return MandrilesInDb;

        }

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithHabilidadesFromDb(int targetMandrilId, int targetSkillId)
        {
            var MandrilesWithHabilidades = _contextDb.MandrilWithSkills.Include(m => m.Mandril.id == targetMandrilId).Include(h => h.Habilidad.id == targetSkillId)
                .AsNoTracking().ToList();
            if (MandrilesWithHabilidades.Count is 0) { }

            _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);

            return MandrilesWithHabilidades;
        }

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithHabilidadesFromDb()
        {
            var MandrilesAllWithHabilidades = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilHabilidades => mandrilHabilidades.Habilidad)
                //verificar las diferencias con y sin cargar
                //Se Carga tambien la potencia de la habilidad para mas detalles
                .Include(p => p.PotenciaMS)
                //Usa menos memoria ya que no carga los objetos en memoria. Ideal para solo lectura.
                .AsNoTracking().ToList();
            
            if (MandrilesAllWithHabilidades.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return MandrilesAllWithHabilidades;
            
            } else return MandrilesAllWithHabilidades;

         
        }





    }
}
