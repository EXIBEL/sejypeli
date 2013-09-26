using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class pong : PhysicsGame
{
    Vector nopeusYlos = new Vector(0, 200);
    Vector nopeusAlas = new Vector(0, -200);
    
    PhysicsObject pallo;
    PhysicsObject maila1;
    PhysicsObject maila2; 

    IntMeter pelaajan1Pisteet; 
    IntMeter pelaajan2pisteet;
        
    public override void Begin()
    {
        LuoKentta();
        AsetaOhjaimet(); 
        LisaaLaskurit();
        AloitaPeli();       

        // TODO: Kirjoita ohjelmakoodisi tähän
       
    }

    void LuoKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);
        pallo.Shape = Shape.Circle;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        pallo.Restitution = 1.0; 
        pallo.KineticFriction = 0.0; 
        pallo MomentOfIntertia = double.PositiveInfinity;
        Add(pallo); 
        AddCollisionHandler (pallo, KasittelePallonTormays);

        maila1 = LuoMaila(Level.Left + 20.0, 0.0);
        maila2 = LuoMaila(Level.Right - 20.0, 0.0); 

        vasenReuna = Level.CreateBorders(); 
        vasenreuna.Restitution = 1.0; 
        vasenReuna.KineticFriction = 0.0; 
        vasenreuna.IsVisible =false;

        Level.CreateBorders(1.0, false); 
        
        Level.BackgroundColor = Color.Black;

        Camera.ZoomToLevel();
    }

    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }
    PhysicsObject LuoMaila(double x, double y)
    {
        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
        return maila;
    }
    void AsetaOhjaimet() 
    {
        Keyboard.Listen(Key.W, ButtonState.Down, AsetaNopeus, "Pelaaja 1: Liikuta mailaa ylös", maila1, nopeusYlos);
        Keyboard.Listen(Key.W, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero);
        Keyboard.Listen(Key.S, ButtonState.Down, AsetaNopeus, "Pelaaja 1: Liikuta mailaa alas", maila1, nopeusAlas);    
        Keyboard.Listen(Key.S, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero); 
    
        Keyboard.Listen(Key.Up, ButtonState.Down, AsetaNopeus, "Pelaaja 2: Liikuta mailaa ylös", maila2, nopeusYlos);
        Keyboard.Listen(Key.Up, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero);
        Keyboard.Listen(Key.Down, ButtonState.Down, AsetaNopeus, "pelaaja 2: Liikuta mailaa alas", maila2, nopeusAlas);
        Keyboard.Listen(Key.Down, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero); 

        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    
        ControllerOne.Listen(Button.DPadUp, ButtonState.Down, AsetaNopeus, "Liikuta mailaa ylös", maila1, nopeusYlos);
        ControllerOne.Listen(Button.DPadUp, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero);
        ControllerOne.Listen(Button.DPadDown, ButtonState.Down, AsetaNopeus, "Liikuta mailaa alas", maila1, nopeusAlas);
        ControllerOne.Listen(Button.DPadDown, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero);

        ControllerTwo.Listen(Button.DPadUp, ButtonState.Down, AsetaNopeus, "Liikuta mailaa ylös", maila2, nopeusYlos);
        ControllerTwo.Listen(Button.DPadUp, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero);
        ControllerTwo.Listen(Button.DPadDown, ButtonState.Down, AsetaNopeus, "Liikuta mailaa alas", maila2, nopeusAlas);
        ControllerTwo.Listen(Button.DPadDown, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero);

        ControllerOne.Listen(Button.Back, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        ControllerTwo.Listen(Button.Back, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
   
    void AsetaNopeus(PhysicsObject maila, Vector nopeus)
    {
       if ((nopeus.Y < 0) && (maila.Bottom < Level.Bottom))
       { 
           maila.Velocity = nopeus;
           return;
    }
    if ((nopeus.Y > 0) && (maila.Top > Level.Top))    
    }
        maila.Velocity = Vector.Zero; 
        return; 
    } 
    
  