using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missioneer.ObjectConstructors
{
    public class Collectables
    {
        public static Item SuperJump(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "SuperJumpItem");
        public static Item SuperSpeed(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "SuperSpeedItem");
        public static Item ShockAbsorber(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "ShockAbsorberItem");
        public static Item SuperBounce(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "SuperBounceItem");
        public static Item GravityModifier(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "AntiGravityItem");
        public static Item Helicopter(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "HelicopterItem");
        public static Item Fireball(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "FireballItem");
        public static Item Bubble(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "BubbleItem");
        public static Item Teleporter(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "TeleportItem");
        public static Item Timetravel(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "TimeTravelItem");
        public static Item Anvil(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "AnvilItem");
        public static Item NestEgg(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "NestEgg_PQ");
        public static Item Gem(string Pos, string Rot, string Scale) => new Item(new Vector(Pos), new AngAxis(Rot), new Vector(Scale), "GemItem_PQ");

    }
}
