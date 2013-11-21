using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class AssassinsFight : PhysicsGame
{
    PlatformCharacter Ukko;
    Image paaukko = LoadImage("paaukko");
    PlatformCharacter vihollinen;
  
    public override void Begin()
    {


        Luokentta();

        Gravity = new Vector(0, -100);
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.D, ButtonState.Down, Liikuta, "oikealle", Direction.Right);
        Keyboard.Listen(Key.A, ButtonState.Down, Liikuta, "vasemmalle", Direction.Left);
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
        Ukko = new PlatformCharacter(leveys / 2, korkeus);
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
        vihollinen = new PlatformCharacter(leveys/2, korkeus);
        vihollinen.Color = Color.FromHexCode("FF0000");
        vihollinen.Image = LoadImage("vihollinen");
        vihollinen.Position = paikka;
        
        /*RandomMoverBrain satunnaisAivot = new RandomMoverBrain(200);
        satunnaisAivot.ChangeMovementSeconds = 3;
        vihollinen.Brain = satunnaisAivot;
        satunnaisAivot.Speed = 100;
        satunnaisAivot.Active = true;
        satunnaisAivot.TurnWhileMoving = true;
        vihollinen.CanRotate = false;*/ 

        PlatformWandererBrain tasoAivot = new PlatformWandererBrain();
        tasoAivot.Speed = 100;

        vihollinen.Brain = tasoAivot;

        Add(vihollinen);
    }

    void Liikuta(Direction suunta)
    {
        if (suunta == Direction.Left)
        {
            Ukko.Walk(-500);
        }
        else
        {
            Ukko.Walk(500);
        }
        //Ukko.Velocity = new Vector(500, 0);

    }

}




