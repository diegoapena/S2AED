using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Skill Traget;
    public int Level;

    public List<Skill> LearndSkills;
    public void Start()
    {
     

    }

    public void checkName(Skill target)
    {
        if(target == null)
        {
            Debug.LogWarning("Traget Skill is null.");
            return;
        }
        SkillManager.Instance.NameOfSkill(target);
    }


    public void TrytoLearnSkill()
    {
        if(SkillManager.Instance.TryLearnSkill(this, Traget, out Skill result))
            {
                LearndSkills.Add(result);
                Debug.Log("Skill learned successfully!");
               if(LearndSkills.Exist(<Skill> target))
                {
                    Debug.Log("The skill is already in the learned skills list.");
                }
            }
            else
            {
                Debug.Log("Failed to learn the skill.");
        }
    }
}
