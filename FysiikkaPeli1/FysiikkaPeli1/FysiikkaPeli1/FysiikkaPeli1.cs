using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class FysiikkaPeli1 : PhysicsGame
{
    PhysicsObject Ukko;
    public override void Begin()
    {
        Camera.ZoomFactor = 16.9;
        Image taustaKuva = LoadImage("aloitus paikka");
        Ukko = new PhysicsObject(6,9); 
        Image PU = LoadImage("paaukko");
        Ukko.Image = PU;
        Surface alaReuna = Surface.CreateBottom(Level);
        Add(alaReuna);

        Add(Ukko);
        
        Level.Background.Image = taustaKuva;


        Keyboard.Listen(Key.Right, ButtonState.Pressed, LiikutaHahmoa,"Liikuttaa hahmoa",1);
 

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void LiikutaHahmoa(int suunta)
    {
    Ukko.Move(new Vector(suunta * 10, 0));
    }

}
