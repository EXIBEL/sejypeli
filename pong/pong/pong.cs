using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class pong : PhysicsGame
{
    PhysicsObject pallo;
    public override void Begin()
    {
        LuoKentta();
        AloitaPeli();
        AloitaPeli();

        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);

        // TODO: Kirjoita ohjelmakoodisi tähän
    }

    void LuoKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);
        pallo.Shape = Shape.Circle;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        pallo.Restitution = 1.0;
        Add(pallo);

        LuoMaila(Level.Left + 20.0, 0.0);
        LuoMaila(Level.Right - 20.0, 0.0);

        Level.CreateBorders(1.0, false);
        Level.BackgroundColor = Color.Black;

        Camera.ZoomToLevel();
    }

    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }
    void LuoMaila(double x, double y)
    {
         PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0); 
         maila.Shape = Shape.Rectangle;
         maila.X = x;
         maila.Y = y;
         maila.Restitution = 1.0;
         Add(maila); 

   void AsetaOhjaimet() 
   }
      Keyboard.Listen(Key.A, ButtonState.Down, LiikutaMaila1Ylös, "Pelaaja 1: Liikuta mailaa ylös");
      Keyboard.Listen(Key.A, ButtonState.Released, PysaytaMaila1, null);

      Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");   
} 


