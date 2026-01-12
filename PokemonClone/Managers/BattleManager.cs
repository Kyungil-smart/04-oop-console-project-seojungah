
public class BattleManager
{
        private static Random _random = new Random();
        private static Monster[] _monsterList = new Monster[]
        {
            new Monster("피카츄", 100, 20, 15, MonsterType.Electric),
            new Monster("이상해씨", 120, 15, 10, MonsterType.Grass),
            new Monster("파이리", 110, 18, 12, MonsterType.Fire),
            new Monster("꼬부기", 130, 14, 9, MonsterType.Water),
            new Monster("이브이", 90, 15, 13, MonsterType.Normal),
            new Monster("잠만보", 250, 10, 5, MonsterType.Normal),
            new Monster("팬텀", 80, 25, 18, MonsterType.Ghost),
            new Monster("망나뇽", 180, 22, 14, MonsterType.Dragon),
            new Monster("뮤츠", 200, 30, 20, MonsterType.Psychic),
            new Monster("갸라도스", 170, 24, 11, MonsterType.Water)
        };
        public static ActionType ActionState {get; set;}
        
        public static Monster GetRandomMonster()
        {
            int index = _random.Next(0, _monsterList.Length);
        
            Monster selected = _monsterList[index];
            return new Monster(selected.Name, selected.Health, selected.Damage, selected.Speed, selected.Type);

            BattleManager.ActionState = ActionType.MonsterAttack;
        }
}

public enum ActionType
{
    PlayerAttack,
    MonsterAttack,
    PlayerHealing,
    MonsterHealing,
    None
}