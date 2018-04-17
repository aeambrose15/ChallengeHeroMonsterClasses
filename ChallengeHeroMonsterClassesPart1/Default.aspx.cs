using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character Hero = new Character();
            Hero.Name = "Wonder Woman";
            Hero.Health = 50;
            Hero.DamageMaximum = 5;
            Hero.AttackBonus = false;

            Character Monster = new Character();
            Monster.Name = "Batman";
            Monster.Health = 50;
            Monster.DamageMaximum = 10;
            Monster.AttackBonus = true;

            Dice dice = new Dice();

            if (Hero.AttackBonus)
               Monster.Defend(Hero.Attack(dice));
            if (Monster.AttackBonus)
                Hero.Defend(Monster.Attack(dice));

            while(Hero.Health > 0 && Monster.Health > 0)
            {
                Monster.Defend(Hero.Attack(dice));
                Hero.Defend(Monster.Attack(dice));

                printStats(Hero);
                printStats(Monster);
            }

            displayResult(Hero, Monster);
              
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("<p>Both {0} and {1} are died.</p>", opponent1.Name, opponent2.Name);
            else if (opponent1.Health <= 0)
                resultLabel.Text += String.Format("<p>{0} defeats {1}</p>", opponent2.Name, opponent1.Name);
            else
                resultLabel.Text += String.Format("<p>{0} defeats {1}</p>", opponent1.Name, opponent2.Name);
        }

        private void printStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3} </p>", 
                character.Name,
                character.Health, 
                character.DamageMaximum.ToString(), 
                character.AttackBonus.ToString());
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            // Random random = new Random();
            //int damage = random.Next(this.DamageMaximum);

            dice.Sides = this.DamageMaximum;
            return  dice.Roll();
        }
          

       public void Defend(int damage)
        {
            this.Health -= damage;
        }
            
     }
    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(this.Sides);
        }
    }
}