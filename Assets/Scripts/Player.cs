using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Skill Target;

    public int Level;

    public List<Skill> LearndSkills;


    private void Start()
    {
        // Simular recorrer todas las habilidades
        foreach (var skill in SkillManager.Instance.AllSkills)
        {
            Debug.Log($"Habilidad disponible: {skill.SkillName}");
        }

        // Verificar si el jugador puede aprender una habilidad
        if (SkillManager.TryFind(SkillManager.Instance.AllSkills.ToArray(), s => s.LevelRestriction <= Level, out Skill targetSkill))
        {
            TryToLearnSkill(targetSkill);
        }

        // Recorrer habilidades aprendidas
        foreach (var learnedSkill in LearndSkills)
        {
            Debug.Log($"Habilidad aprendida: {learnedSkill.SkillName}");
        }
    }

    public void CheckName(Skill target)
    {
        if (target == null)
        {
            Debug.LogWarning("Target skill is null.");
            return;
        }

        SkillManager.ExecuteAction(target, skill => Debug.Log($"Nombre de la habilidad: {skill.SkillName}"));
    }

    public void TryToLearnSkill(Skill target)
    {
        if (SkillManager.ValidateCondition(target, skill => skill.LevelRestriction <= Level))
        {
            if (LearndSkills.Contains(target))
            {
                Debug.Log("Ya has aprendido esta habilidad");
                return;
            }

            LearndSkills.Add(target);
            Debug.Log("Habilidad añadida");
        }
        else
        {
            Debug.Log($"No puedes aprender esta habilidad. Requiere nivel {target.LevelRestriction}");
        }
    }
}
