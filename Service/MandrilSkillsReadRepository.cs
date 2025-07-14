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
        public IReadOnlyList<Skill> GetOneSkillFromDb(int targetHabilidadId)
        {
            

            var HabilidadInDb = _contextDb.Skills.Where(h => h.id == targetHabilidadId).AsNoTracking().ToList();
            if (HabilidadInDb.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageUsers.SkillNotFound, HabilidadInDb);
                
                return HabilidadInDb;
            }
            else {
               
                return HabilidadInDb;
            }

        }
        public IReadOnlyList<Skill> GetAllSkillsFromDb()
        {

            //Este metodo obtiene todas las habilidades de la base de datos.
            //Se usara en un controller  propio de skills
            var HabilidadesInDb = _contextDb.Skills.AsNoTracking().ToList();
            if (HabilidadesInDb.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundSkills);

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

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromDb(int targetMandrilId, int targetSkillId)
        {
            var MandrilesWithHabilidades = _contextDb.MandrilWithSkills.Include(m => m.Mandril).Include(h => h.Skill)
                .Where(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId).ToList();

            if (MandrilesWithHabilidades.Count is 0)
            {
               
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                _logger.LogWarning(DefaultsMessageDevs.NotFoundRelationSkill,targetSkillId, targetMandrilId);

                return MandrilesWithHabilidades;
            }else
            {
                return MandrilesWithHabilidades;
            }
        
        }

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkills()
        {
            var MandrilesAllWithHabilidades = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilSkills => mandrilSkills.Skill)
                //verificar las diferencias con y sin cargar
                //Se Carga tambien la potencia de la habilidad para mas detalles
                .Include(p => p.PowerMS)
                //Usa menos memoria ya que no carga los objetos en memoria. Ideal para solo lectura.
                .AsNoTracking().ToList();
            
            if (MandrilesAllWithHabilidades.Count is 0)
            {
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return MandrilesAllWithHabilidades;
            
            } else return MandrilesAllWithHabilidades;
        }

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkills(int targetMandrilId)
        {
            var MandrilWithHabilidades = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilSkills => mandrilSkills.Skill)
                .Where(m => m.Mandril.id == targetMandrilId).ToList();
                
               

            if (MandrilWithHabilidades is not null)
            {
                //Si el mandril con habilidades no es null, se retorna la lista de habilidades del mandril.
                return MandrilWithHabilidades.ToList();
            }
            else{
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                return null;

            }
        }





    }
}
