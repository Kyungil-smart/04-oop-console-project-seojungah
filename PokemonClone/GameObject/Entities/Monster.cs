
public class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Damage { get; set; }
    public int Speed { get; set; }
    public MonsterType Type { get; set; }
    public Monster(string name, int health, int damage, int speed, MonsterType type)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Speed = speed;
        Type = type;
    }
    
    public void GetDamage(int damage)
    {
        Health -= damage;
    }


}

public enum MonsterType
{
    Normal, Fire, Water, Grass, Electric, Psychic, Ghost, Dragon
}