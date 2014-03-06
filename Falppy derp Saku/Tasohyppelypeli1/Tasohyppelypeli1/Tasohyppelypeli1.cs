using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Tasohyppelypeli1 : PhysicsGame
{
    const double nopeus = 200;
    const double hyppyNopeus = 750;
    Image Kentta;
    PhysicsObject Lintu;
    Image Lintu2 = LoadImage("Saku");
    
   

    public override void Begin()
    {
        LisaaNappaimet();
        LuoKenttaHa();
        LuoLintu();
    }


    void LuoLintu()
    {
       Lintu = new PhysicsObject(50,50);
       
       
       
        Lintu.Position = Camera.Position;
        Lintu.Image = Lintu2;
        Add(Lintu);
    
    }


    
    
    
    
    
    
    
    
    
    
    
    
    void LisaaNappaimet()
    {
        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "lolo");

        //Keyboard.Listen(Key.Left, ButtonState.Down, Liikuta, "Liikkuu vasemmalle", Saku, -nopeus);
        //Keyboard.Listen(Key.Right, ButtonState.Down, Liikuta, "Liikkuu vasemmalle", Saku, nopeus);
        //Keyboard.Listen(Key.Up, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", Saku, hyppyNopeus);

        //ControllerOne.Listen(Button.Back, ButtonState.Pressed, Exit, "Poistu pelistä");

        //ControllerOne.Listen(Button.DPadLeft, ButtonState.Down, Liikuta, "Pelaaja liikkuu vasemmalle", Saku, -nopeus);
        //ControllerOne.Listen(Button.DPadRight, ButtonState.Down, Liikuta, "Pelaaja liikkuu oikealle", Saku, nopeus);
        //ControllerOne.Listen(Button.A, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", Saku, hyppyNopeus);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
    }
    void Liikuta(PlatformCharacter Saku,double nopeus)
   { 
    
   }
    void Hyppaa(PlatformCharacter Saku,double hyppyNopeus)
    {
     
    }
    void LuoKenttaHa()
    {
        Kentta = LoadImage("Kentta");
        Level.Background.Image = Kentta;
        Camera.Zoom(1.70);
        
     }

}    