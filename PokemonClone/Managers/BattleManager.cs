
public class BattleManager
{
        private static Random _random = new Random();
        private static Monster[] _monsterList = new Monster[]
        {
            new Monster("피카츄", 100, 20, MonsterType.Electric),
            new Monster("이상해씨", 120, 15, MonsterType.Grass),
            new Monster("파이리", 110, 18, MonsterType.Fire),
            new Monster("꼬부기", 130, 14, MonsterType.Water),
            new Monster("이브이", 90, 15, MonsterType.Normal),
            new Monster("잠만보", 250, 10, MonsterType.Normal),
            new Monster("팬텀", 80, 25, MonsterType.Ghost),
            new Monster("망나뇽", 180, 22, MonsterType.Dragon),
            new Monster("뮤츠", 200, 30, MonsterType.Psychic),
            new Monster("갸라도스", 170, 24, MonsterType.Water)
        };
        public static ActionType ActionState = ActionType.None;
        public static Monster GetRandomMonster()
        {
            int index = _random.Next(0, _monsterList.Length);
        
            Monster selected = _monsterList[index];
            return new Monster(selected.Name, selected.Health, selected.Damage, selected.Type);
        }

        public static void  CheckBattleOver()
        {
            bool battleOver = true;
            foreach (Monster monster in _monsterList)
            {
                if (monster.Health > 0)
                {
                    return;
                }
            }
            
            GameManager.IsGameOver = true;
        }
}

public enum ActionType
{
    None,
    PlayerAttack,
    MonsterAttack,
    PlayerHealing,
    MonsterHealing
}