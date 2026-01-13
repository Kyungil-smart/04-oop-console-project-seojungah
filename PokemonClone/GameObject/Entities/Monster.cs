
public class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    private int _maxHealth;
    public int Mana { get; set; }
    public int Damage { get; set; }
    public MonsterType Type { get; set; }
    public Monster(string name, int health, int damage, MonsterType type)
    {
        Name = name;
        Health = health;
        _maxHealth=health;
        Damage = damage;
        Type = type;
    }
    
    
    public void GetDamage(int damage)
    {
        Health -= damage;
    }
    
    public void HealingHp()
    {
        if (Health + 10 >= _maxHealth) Health = _maxHealth;
        else Health += 10;
        BattleManager.ActionState = ActionType.MonsterAttack;
    }

    public string GetSkillText()
    {
        switch (Type)
        {
            case MonsterType.Normal:
                return "기가임팩트 스킬 공격!";
            case MonsterType.Dragon:
                return "와이드브레이커~~!";
            case MonsterType.Fire:
                return "화염탄 스킬 공격!!";
            case MonsterType.Grass:
                return "기가드레인 공격~~";
            case MonsterType.Electric:
                return "10만볼트!!!";
            case MonsterType.Psychic:
                return "사이코블레이드~~";
            case MonsterType.Ghost:
                return "놀래키기 스킬 공격!";
            case MonsterType.Water:
                return "하이드로펌프!!";
            default:
                return "공격!";
        }
    }
}

public enum MonsterType
{
    Normal, Fire, Water, Grass, Electric, Psychic, Ghost, Dragon
}