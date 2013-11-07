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
    public override void Begin()
    {

       //Ukko = new PhysicsObject(50, 50);
       //Ukko.Image = paaukko;
       //Add(Ukko);
        Luokentta();
    
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.D, ButtonState.Pressed, Liikuta, "oikealle",Direction.Right);
        Keyboard.Listen(Key.A, ButtonState.Pressed, Liikuta, "vasemmalle",Direction.Left);
        Keyboard.Listen(Key.W, ButtonState.Pressed, Liikuta, "ylös",Direction.Up); 
        Keyboard.Listen(Key.S, ButtonState.Pressed, Liikuta, "alas",Direction.Down);
    } 
    void Luokentta() {
    
        ColorTileMap ruudut = ColorTileMap.FromLevelAsset("kentta");

        //2. Kerrotaan mitä aliohjelmaa kutsutaan, kun tietyn värinen pikseli tulee vastaan kuvatiedostossa.
        ruudut.SetTileMethod(Color.FromHexCode("0094FF"),LuoPelaaja);
        ruudut.SetTileMethod(Color.FromHexCode("7F3300"),LuoTaso);
        ruudut.SetTileMethod(Color.FromHexCode("FF0000"),LuoVihollinen);
        ruudut.SetTileMethod(Color.FromHexCode("808080"),LuoSeina);

        //3. Execute luo kentän
        //   Parametreina leveys ja korkeus
        ruudut.Execute(10, 10);
    }

    void LuoPelaaja(Vector paikka, double leveys, double korkeus)
    {
        Ukko = new PlatformCharacter2(20, 20);
        Ukko.Position = paikka;
        Ukko.Color = Color.FromHexCode("0094FF");
        Ukko.Image = LoadImage("paaukko");
        Add(Ukko);
    }


    void LuoTaso(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject taso = PhysicsObject.CreateStaticObject(leveys, korkeus);
        taso.Position = paikka;
        //taso.Image = groundImage; 
        taso.Color = Color.FromHexCode("7F3300");
        taso.CollisionIgnoreGroup = 1; 
        Add(taso);
    }
    
    void LuoSeina(Vector paikka, double leveys, double korkeus)
    {
    PhysicsObject Seina = new PhysicsObject(80, 80);
   
    }
    void LuoVihollinen(Vector paikka, double leveys, double korkeus)  
    {
    LuoVihollinen = vihollinen;
    vihollinen = new PlatformCharacter(20, 20);

    
    
    
    }
    void Liikuta(Direction suunta) 
    
    {
        Ukko.Walk(suunta);
      
    
    
    }

}


 

