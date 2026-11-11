using System;

namespace WeaponSystemModule
{
    public class WeaponSystem
    {
        private float reloadTime;
        private float lastShotTime;
        private int baseDamage;

        public WeaponSystem(float reloadTime, int baseDamage)
        {
            this.reloadTime = reloadTime;
            this.lastShotTime = -reloadTime; 
            this.baseDamage = baseDamage;
        }

        public string TryShoot(float currentTime, bool isHit)
        {
            if (currentTime - lastShotTime < reloadTime)
            {
                return "Ошибка: Орудие перезаряжается!";
            }

            lastShotTime = currentTime;

            if (!isHit)
            {
                return "Выстрел произведен. Промах!";
            }

            return "Попадание! Нанесено урона: " + baseDamage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование модуля WeaponSystem");
            WeaponSystem gun = new WeaponSystem(reloadTime: 2.0f, baseDamage: 50);

            Console.WriteLine(gun.TryShoot(0.5f, true)); 
            Console.WriteLine(gun.TryShoot(2.5f, false)); 
            Console.WriteLine(gun.TryShoot(3.0f, true)); 
            Console.WriteLine(gun.TryShoot(5.0f, true)); 
        }
    }
}