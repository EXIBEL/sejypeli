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
    Image paaukko = LoadImage("paaukko");
    public override void Begin()
    {

       //Ukko = new PhysicsObject(50, 50);
       //Ukko.Image = paaukko;
       //Add(Ukko);
        Luokentta();
     
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void Luokentta() {
    
        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("kentta");

        //2. Kerrotaan mitä aliohjelmaa kutsutaan, kun tietyn värinen pikseli tulee vastaan kuvatiedostossa.
        ruudut.SetTileMethod(Color.FromHexCode("0094FF"),LuoPelaaja);
        ruudut.SetTileMethod(Color.FromHexCode("7F3300"),LuoTaso);
        ruudut.SetTileMethod(Color.FromHexCode("FF0000"),LuoVihollinen);

        //3. Execute luo kentän
        //   Parametreina leveys ja korkeus
        ruudut.Execute(20, 20);
    }

    void LuoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        Ukko = new PlatformCharacter(10, 10);
        Ukko.Position = paikka;
        Add(Ukko);
    }

    void LuoTaso(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(leveys, korkeus);
        taso.Position = paikka;
        //taso.Image = groundImage;
        taso.CollisionIgnoreGroup = 1;
        Add(taso);
    }
    void LuoVihollinen(Vector paikka, double leveys, double korkeus)
}

