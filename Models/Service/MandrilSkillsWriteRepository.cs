using MandrilAPI.Interfaces;

namespace MandrilAPI.Models.Service
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

        public MandrilWithSkills AssignExistingHabilidadToMandril(int targetMandrilId, int targetHabilidadId)
        {
             
        }

        public MandrilWithSkills DeleteExistingHabilidadFromMandril(int targetHabilidadId)
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

        public MandrilWithSkills UpdatePotenciaOfHabilidadForMandril(int targetMandrilId, int targetHabilidadId, int newPotencia)
        {
            
        }
    }
}
