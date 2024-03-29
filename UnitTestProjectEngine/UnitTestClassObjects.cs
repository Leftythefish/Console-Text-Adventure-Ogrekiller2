using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectEngine
{
    [TestClass]
    public class UnitTestClassObjects
    {
        ///<summary>
        ///--Ria--
        /// Unit tests for class object creation
        ///</summary>

        [TestMethod]
        public void ClassConstructors_CreatingItemclassobject_willnotcrash()
        {
            Item x = new Item("Esine");
            string expected = "Esine";
            string result = x.Name;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemWeaponclassobject_willnotcrash()
        {
            Weapon x = new Weapon("Axe", 10);
            string expected = "Axe 10";
            Player p = new Player("Joe", 100);
            p.Inventory.Add(x);
            string result = x.Name + " " + x.Damage;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemPotionclassobject_willnotcrash()
        {
            Potion x = new Potion("Healing potion", 20);
            string expected = "Healing potion 20";
            string result = x.Name + " " + x.Healing_Amount;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingCreatureMonsterclassobject_willnotcrash()
        {
            Monster x = new Monster("Orc", 50);
            string expected = "Orc 50";
            string result = x.Name + " " + x.Max_Health;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlayerMovement_Damagecalculator_ReturnsANumber()
        { //--method was removed
            //int basedamage = 10;
            //int damage = PlayerActions.HitCalculator(basedamage);
            //System.Console.WriteLine(damage);
        }
    }
}
