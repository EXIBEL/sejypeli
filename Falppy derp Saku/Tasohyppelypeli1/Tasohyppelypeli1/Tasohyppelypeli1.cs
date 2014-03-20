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
        Gravity = new Vector( 0.0, -200.0 );
        LisaaNappaimet();
        LuoKenttaHa();
        LuoLintu();
        liikkuvatausta();
        //liikutapelaajaa();  
    }


   

    void LuoLintu()
    {
        Lintu = new PhysicsObject(50, 50);


        Lintu.Position = Camera.Position;
        Lintu.Image = Lintu2;
        Add(Lintu);

    }



    void LisaaNappaimet()
    {

        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "lolo");
        Keyboard.Listen(Key.Space, ButtonState.Pressed, lintuhyppaaa, "asd");


        //Keyboard.Listen(Key.Right, ButtonState.Down, Liikuta, "Liikkuu vasemmalle", Saku, nopeus);
        //Keyboard.Listen(Key.Up, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", Saku, hyppyNopeus);

        //ControllerOne.Listen(Button.Back, ButtonState.Pressed, Exit, "Poistu pelistä");

        //ControllerOne.Listen(Button.DPadLeft, ButtonState.Down, Liikuta, "Pelaaja liikkuu vasemmalle", Saku, -nopeus);
        //ControllerOne.Listen(Button.DPadRight, ButtonState.Down, Liikuta, "Pelaaja liikkuu oikealle", Saku, nopeus);
        //ControllerOne.Listen(Button.A, ButtonState.Pressed, Hyppaa, "Pelaaja hyppää", Saku, hyppyNopeus);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
    }
    void Liikuta(PlatformCharacter Saku, double nopeus)
    {

    }
    void Hyppaa(PlatformCharacter Saku, double hyppyNopeus)
    {

    }
    void LuoKenttaHa()
    {
        Camera.Zoom(1.70);
    }

   void liikkuvatausta()
    {
        
       Image bgImg = LoadImage("kentta");

        GameObject liikkuvaTausta = new GameObject(bgImg.Width * 10, bgImg.Height);

        liikkuvaTausta.Image = bgImg;

        liikkuvaTausta.TextureWrapSize = new Vector(10.0, 1.0); // 10 kertaa kuvan levyinen
       
        
        Add(liikkuvaTausta, -3);
        
        liikkuvaTausta.MoveTo(new Vector(-Screen.Width, 0), 100);
       
    }


    void lintuhyppaaa()
    {
        Lintu.Hit(new Vector(50, 500));



    }


}
 



















































