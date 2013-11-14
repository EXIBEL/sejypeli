using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class FysiikkaPeli1 : PhysicsGame
{
    PlatformCharacter2 Ukko;
    Image paaukko = LoadImage("paaukko");
    PlatformCharacter vihollinen;
    public override void Begin() 
    {

        //Ukko = new PhysicsObject(50, 50);
        //Ukko.Image = paaukko;
        //Add(Ukko);
        Luokentta();

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.D, ButtonState.Pressed, Liikuta, "oikealle", Direction.Right);
        Keyboard.Listen(Key.A, ButtonState.Pressed, Liikuta, "vasemmalle", Direction.Left);
        Keyboard.Listen(Key.W, ButtonState.Pressed, Hyppaa, "ylös");
        Keyboard.Listen(Key.S, ButtonState.Pressed, Liikuta, "alas", Direction.Down); 

    
    }
    void Hyppaa()
    {
        Ukko.Jump(500); 
    }     
    void Luokentta()
    {

        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("kentta");

        //2. Kerrotaan mitä aliohjelmaa kutsutaan, kun tietyn värinen pikseli tulee vastaan kuvatiedostossa.
        ruudut.SetTileMethod(Color.FromHexCode("0094FF"), LuoPelaaja);
        ruudut.SetTileMethod(Color.FromHexCode("7F3300"), LuoTaso);
        ruudut.SetTileMethod(Color.FromHexCode("FF0000"), LuoVihollinen);

        //3. Execute luo kentän
        //   Parametreina leveys ja korkeus
        ruudut.Execute(50, 50);
    }

    void LuoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        Ukko = new PlatformCharacter2(50, 50);
        Ukko.Position = paikka;
        Ukko.Color = Color.FromHexCode("0094FF");
        Ukko.Image = LoadImage("paaukko");
        Add(Ukko);
        Camera.Follow(Ukko);
        Camera.ZoomFactor = 2; 
        Gravity = new Vector(0, -1000);
    }


    void LuoTaso(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(leveys, korkeus);
        taso.Position = paikka;
        taso.Color = Color.FromHexCode("7F3300");
        taso.CollisionIgnoreGroup = 1; 
        Add(taso);
    }
    void LuoVihollinen(Vector paikka, double leveys, double korkeus)  
    {
        vihollinen = new PlatformCharacter(20, 20);
        vihollinen.Color = Color.FromHexCode("FF0000");
        //vihollinen.Image = LoadImage("vihollinen");
        Add(vihollinen);
    }

    void Liikuta(Direction suunta)
    {
        Ukko.Walk(suunta);
        Ukko.Velocity = new Vector(500, 0);

    }

}
 

 

