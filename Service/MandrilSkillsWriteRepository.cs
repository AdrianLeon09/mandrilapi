using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;

namespace MandrilAPI.Service
{
    public class MandrilSkillsWriteRepository(MandrilDbContext contextDb) : IMandrilAndSkillsWriteRepository
    {
        private readonly MandrilDbContext _contextDb = contextDb;

        public Skill AddNewHabilidadToDb(SkillDTO newSkillDto)
        {
            Skill skill = new Skill();
            skill.Nombre = newSkillDto.Nombre;
           
            _contextDb.Skills.Add(skill);
            _contextDb.SaveChanges();
            return skill;
        }

        public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto)
        {
            Mandril mandril = new Mandril();
            mandril.Nombre = newMandrilDto.Nombre;

            _contextDb.Mandrils.Add(mandril);
            _contextDb.SaveChanges();
            return mandril;
        }

        public MandrilWithSkillsIntermediateTable AssignOneHabilidadToMandril(int targetMandrilId, int targetHabilidadId)
        {
            var mandril = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);
            var skill = _contextDb.Skills.FirstOrDefault(h => h.id == targetHabilidadId);

            var relation = new MandrilWithSkillsIntermediateTable();
            relation.Mandrilid = targetMandrilId;
            relation.Habilidadid = targetHabilidadId;
            relation.PotenciaMH = 0; //default

            _contextDb.SaveChanges();
             
        }

        public MandrilWithSkillsIntermediateTable DeleteHabilidadFromMandril(int targetHabilidadId)
        {
          
        }

        public Skill DeleteOneHabilidadFromDb(int targetHabilidadId)
        {
             
        }

        public Mandril DeleteOneMandrilFromDb(int targetIdMandril)
        {
            
        }

        public Skill UpdateOneHabilidadToDb(int targetHabilidadId, SkillDTO habilidadDTO)
        {
             
        }

        public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto)
        {
            
        }

        public MandrilWithSkillsIntermediateTable UpdatePotenciaOfHabilidadForMandril(int targetMandrilId, int targetHabilidadId, int newPotencia)
        {
            
        }
    }
}
