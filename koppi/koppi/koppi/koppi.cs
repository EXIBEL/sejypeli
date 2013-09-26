using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class koppi : PhysicsGame
{
    IntMeter elamat, omenoitaIlmassa, pisteLaskuri; 
    public override void Begin()
    {

       // Luo reunat  
        IntMeter pisteLaskuri;
        IntMeter elamat = new IntMeter(3,0,5); 
        int level = 1;
        int omenoitailmassa = 1; 

        Level.CreateLeftBorder();
        Level.CreateRightBorder();
        PhysicsObject pohja =
            Level.CreateBottomBorder();
        AddCollisionHandler(pohja, PutosiMaahan);

        LuoOmena();
        LuoPistelaskuri();

        Gravity = new Vector(0.0, -100.0);

        IsMouseVisible = true;
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    } 
  
    void OmenaaKlikattu(PhysicsObject KlikattuOmena)
    {
        KlikattuOmena.Destroy(); 
        //jotain... 
    }
    void LuoOmena(int level)
    {
        PhysicsObject omena = new PhysicsObject(50, 50);
        omena.Shape = Shape.Circle;
        omena.Color = Color.Red;
        GameObject lehti = new GameObject(10, 10);
        lehti.Shape = Shape.Heart;
        lehti.Color = Color.Green;
        Add(omena);
        lehti.Y = 30;
        omena.Add(lehti);
        Mouse.ListenOn(omena, MouseButton.Left,
        ButtonState.Pressed, OmenaaKlikattu,
        "omenaa klikattu", omena);

        //Mouse.ListenOn(omena, MouseButton.Left,
        //ButtonState.Pressed, OmenaaKlikattu,
        //"omenaa klikattu");

        omena.Hit(RandomGen.NextVector(50, 300));
    }
    void PutosiMaahan(PhysicsObject maa, PhysicsObject omena) 
    {    
        if(omena.Color !=Color.Black)  
    {
        elamat.AddValue(-1); 
        omena.Color = Color.Black;
        omenoitaIlmassa = omenoitaIlmassa -1;     
    {
    void LuoElamalaskuri()
    {
       Label elamanaytto = new Label();
       elamanaytto.BindTo(elamat); 
       elamanaytto.X = Screen.Right -50.0;
       elamanaytto.Y = Screen.Top -50.0; 
       Add(elamanaytto);
    }
    void LuoPistelaskuri() 
    {
        pisteLaskuri = new IntMeter(0);

        Label pistenaytto = new Label();
        pistenaytto.X = Screen.Left + 100;
        pistenaytto.Y = Screen.Top - 100;
        pistenaytto.TextColor = Color.Black;
        pistenaytto.Color = Color.White;

        pistenaytto.BindTo(pisteLaskuri);
        Add(pistenaytto);
    }
    void OmenaNapattu() 
    {
    if (OmenaNapattu.tag != "maassa") 
    }
     Remove(OmenaNapattu); 
     OmenaNapattu
}




 

   
    
 