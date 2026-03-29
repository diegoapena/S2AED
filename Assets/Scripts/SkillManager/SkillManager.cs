using System;
using System.Collections.Generic;
using UnityEngine;
 
public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [SerializeField] private List<Skill> skillList;

    // Propiedad pública para acceder a la lista de habilidades
    public List<Skill> AllSkills => skillList;

    // Método genérico para validar condiciones previas
    public static bool ValidateCondition<T>(T skill, Func<T, bool> condition)
    {
        return condition != null && condition(skill);
    }

    // Método genérico para ejecutar acciones en habilidades
    public static void ExecuteAction<T>(T skill, Action<T> action)
    {
        action?.Invoke(skill);
    }

    public void NameOfSkill<T>(T skill) where T : Skill
    {
        Debug.Log(skill.SkillName);
    }

    // Método genérico de búsqueda con out
    public static bool TryFind<T>(T[] skills, Func<T, bool> condition, out T result)
    {
        foreach (var skill in skills)
        {
            if (condition(skill))
            {
                result = skill;
                return true;
            }
        }
        result = default;
        return false;
    }

    public bool TryLearnSkill<T>(Player sender, T target, out T Result) where T : Skill
    {
        if (sender.Level >= target.LevelRestriction)
        {
            Result = target;
            return true;
        }
        else
        {
            Result = default;
            return false;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //-> COMO IMPLEMENTARLO CON BOTONES
    public void BtnSelectSkill(Skill skill)
    {
        Debug.Log("a");
    }
}
