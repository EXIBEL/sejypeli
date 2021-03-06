﻿using System;
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
    PhysicsObject Lintu;
    Image Lintu2 = LoadImage("Saku");
    PhysicsObject maa;
    Image putkenkuva = LoadImage("putki");
    Image putkenpaakuva = LoadImage("putkenpaa");
    SoundEffect aani = LoadSoundEffect("aani");
    IntMeter PisteLaskuri;


    public override void Begin()
    {




        LuoPistelaskuri();
        Gravity = new Vector(0.0, -200.0);
        LisaaNappaimet();

        LuoKenttaHa();
        LuoLintu();

        liikkuvatausta();

        maa = Level.CreateBottomBorder();
        LuoPutket();
    }


    void LuoPutket()
    {
        // Jotta putket ei törmäile maahan
        maa.CollisionIgnoreGroup = 1;

        double ht = Screen.Height;
        for (int i = 1; i < 10; i++)
        {
            double y = RandomGen.NextDouble(-ht / 5, ht / 5);
            LuoPutki(250 * i, y + 0 + ht / 2);
            //PisteSeina(250 * i, y - 100 );
            LuoPutki(250 * i, y - 200 - ht / 2);
        }
    }
    void LuoPutki(double x, double y)
    {
        double ht = Screen.Height;

        PhysicsObject putki = new PhysicsObject(50, ht);
        putki.Tag = "putki";
        putki.Image = putkenkuva;

        PhysicsObject putkenpaaAla = new PhysicsObject(70, 30);
        putkenpaaAla.IgnoresCollisionResponse = true;
        putkenpaaAla.IgnoresGravity = true;
        putkenpaaAla.Image = putkenpaakuva;
        putkenpaaAla.Y = putki.Height / 2;
        putkenpaaAla.Tag = "putki";
        putki.Add(putkenpaaAla);

        PhysicsObject putkenpaaYla = new PhysicsObject(70, 30);
        putkenpaaYla.IgnoresCollisionResponse = true;
        putkenpaaYla.IgnoresGravity = true;
        putkenpaaYla.Image = putkenpaakuva;
        putkenpaaYla.Y = -putki.Height / 2;
        putkenpaaYla.Tag = "putki";
        putki.Add(putkenpaaYla);

        PhysicsObject pisteseina = new PhysicsObject(10, 200);
        pisteseina.IgnoresGravity = true;
        pisteseina.IgnoresCollisionResponse = true;
        pisteseina.Position = new Vector(x, y + putki.Height / 2 + pisteseina.Height / 2);
        pisteseina.IsVisible = false;
        pisteseina.CollisionIgnoreGroup = 1;
        Add(pisteseina);

        // Painovoima ei vaikuta
        putki.IgnoresPhysicsLogics = true;
        putki.CanRotate = false;
        // Ei törmäile maahan
        putki.CollisionIgnoreGroup = 1;
        putkenpaaAla.CollisionIgnoreGroup = 1;
        putkenpaaYla.CollisionIgnoreGroup = 1;
        putki.Position = new Vector(x, y);
        Add(putki);

        AddCollisionHandler(Lintu, pisteseina, Pelaajallepiste);

        // Pistä putket tulemaan lintua kohti
        Vector movePos = new Vector(-ht, y);
        putki.MoveTo(movePos, 100);
        Vector movePosPiste = new Vector(-ht, pisteseina.Y);
        pisteseina.MoveTo(movePosPiste, 100);
    }


    void LuoLintu()
    {
        Lintu = new PhysicsObject(50, 50);


        Lintu.Position = Camera.Position;
        AddCollisionHandler(Lintu, "putki", LintuTormaa);


        Lintu.Image = Lintu2;
        Lintu.CanRotate = false;
        Add(Lintu);

    }



    void LisaaNappaimet()
    {

        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "lolo");
        Keyboard.Listen(Key.Space, ButtonState.Pressed, lintuhyppaaa, "asd");
        Keyboard.Listen(Key.R, ButtonState.Pressed, restart, "moro");
        Keyboard.Listen(Key.S, ButtonState.Pressed, Sammuta, "sammutta");



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
        Image bgImg = LoadImage("kenttatausta v1");
        GameObject liikkuvaTausta = new GameObject(bgImg.Width * 10, bgImg.Height);


        liikkuvaTausta.Image = bgImg;

        liikkuvaTausta.TextureWrapSize = new Vector(10.0, 1.0); // 10 kertaa kuvan levyinen



        Add(liikkuvaTausta, -3);

        liikkuvaTausta.MoveTo(new Vector(-Screen.Width, 0), 100);


    }


    void lintuhyppaaa()
    {

        Lintu.Hit(new Vector(0, 450));

    }


    void LuoPistelaskuri()
    {
        PisteLaskuri = new IntMeter(0);

        Label pisteNaytto = new Label();
        pisteNaytto.X = Screen.Left + 100;
        pisteNaytto.Y = Screen.Top - 100;
        pisteNaytto.TextColor = Color.Black;
        pisteNaytto.Color = Color.White;

        pisteNaytto.BindTo(PisteLaskuri);
        Add(pisteNaytto);
    }


    /*void PisteSeina(double x, double y)
    {
       PhysicsObject pisteseina = PhysicsObject.CreateStaticObject(10, 200);
        pisteseina.IgnoresCollisionResponse = true;
        pisteseina.Position = new Vector(x, y);
        //pisteseina.IsVisible = false;
        double ht = Screen.Height;
        pisteseina.CollisionIgnoreGroup = 1;
        Add(pisteseina);
        AddCollisionHandler(Lintu, pisteseina, Pelaajallepiste);
    }*/

    void LintuTormaa(PhysicsObject kukaTormaa, PhysicsObject mihinTormaa)
    {
        Lintu.Destroy();
        MessageDisplay.Add("You Failed, Press S to Quit");
        MessageDisplay.Add("You Failed, Press R to try again");
        aani.Play();
    }


    public void restart()
    {
        ClearAll();
        Begin();
    }

    void Sammuta()
    {
        Exit();
    }


    public void Pelaajallepiste(PhysicsObject Tormaaja, PhysicsObject kohde)
    {
        PisteLaskuri.Value = +1;
    }



}


