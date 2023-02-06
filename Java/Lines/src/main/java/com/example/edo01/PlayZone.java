package com.example.edo01;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Rect;
import android.os.Bundle;
import android.view.Display;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Toast;

import java.util.TimerTask;
import java.util.Timer;

import static java.lang.Thread.sleep;

public class PlayZone extends Activity {

    boolean style = false;
    String prefName ="ColorDesign";

    int arenaCount = 9;

    float x = 0, y;
    int popox;
    int posSkizb = -1;
    int posHajord = -1;
    int state = 1;
    int strerk = -1;
    int global = 0;
    int global1 = -1;
    int global2 = -1;
    int matrixCErkar = 0;
    int interval = 400; //Timer interval

    Paint fontPaint;
    Paint paint;
    Paint paintBG = new Paint();

    String NameUser;
    String BSTvjal;

    Bitmap bitmapSource1, bitmapSource2, bitmapSource3, bitmapSource4, bitmapSource5,bitmapSource6,bitmapSource7; //Colors
    Bitmap bitmap1, bitmap2, bitmap3, bitmap4, bitmap5,bitmap6,bitmap7;

    Bitmap[] bitmapSourceMove;
    Bitmap[] bitmapMove;

    Bitmap bitmapSourceBscore; //Best Score
    Bitmap bitmapBScore;

    Bitmap[] bitmapkalabok; //Kalabok
    Bitmap[] bitmapSourcekalabok;

    Bitmap[] bitmapknopka; //Knopka
    Bitmap[] bitmapSourceknopka;

    Bitmap bitmapHome; //Home button
    Bitmap bitmapSourceHome;

    Bitmap bitmapSave; //Save button
    Bitmap bitmapSourceSave;

    Bitmap bitmapLoad; //Load button
    Bitmap bitmapSourceLoad;

    Bitmap bitmapBlock; //none color
    Bitmap bitmapSourceBlock;

    boolean ba = false;
    boolean BKalabok = true, BKnopka = true;
    boolean movment = false;

    String[] matrixD;// = new String[64];

    int[] matrixBC;
    int[] matrixC;
    int[] matrixChanaparh;

    int[] gameArena;

    float touchX = 0;
    float touchY = 0;

    int dx; //
    int dy;
    int cmAfterBallX; //
    int cmAfterBallY;

    int chapX;
    int chapY;


    int WBlock;
    int HBlock;

    int cmKnopkaX; //knopka
    int cmKnopkaY;
    int WKnopka;
    int HKnopka;

    int cmKalabokX; //kalabok
    int cmKalabokY;
    int WKalabok;
    int HKalabok;

    int cmDownScoreX;  //Best(Down) Score
    int cmDownScoreY;

    int cmScoreX;  //Score
    int cmScoreY;
    int Score = 0;

    int cmHomeX;  //Home button
    int cmHomeY;

    int cmSaveX;  //Save button
    int cmSaveY;

    int cmLoadX;  //Load button
    int cmLoadY;

    int WBackBtn;
    int HBackBtn;

    int cmBScoreX; //BestScore
    int cmBScoreY;
    int BSWidth;
    int BSHeight;

    int WDevice;
    int HDevice;

    int textScoreChap = 50;

    Timer tm;
    DrawView.MyTimerTask myTimerTask;

    SharedPreferences sPref;
    final String SAVED_TEXT = "saved_text";
    final String BestPlayer = "best";
    String SGame;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(new DrawView(this));
    }

    class DrawView extends View {

        @SuppressLint("NewApi")
        public DrawView(Context context) {
            super(context);

            SharedPreferences prefs = getSharedPreferences(prefName, MODE_PRIVATE);
            int red = prefs.getInt("red", (int)255);
            int green = prefs.getInt("green", (int)255);
            int blue = prefs.getInt("blue", (int)0);
            style = prefs.getBoolean("style", (boolean) true);
            int sp =  prefs.getInt("speed", (int)2);

            switch (sp){
                case 0:
                    interval = 300;
                    break;
                case 1:
                    interval = 150;
                    break;
                case 2:
                    interval = 75;
                    break;
            }

            int colorMain = Color.rgb(red,green,blue);
            int colorAccent = Color.rgb(255-red,255-green,255-blue);

            paintBG.setColor(colorMain);

            Display display = getWindowManager().getDefaultDisplay();

            WDevice = display.getWidth();
            HDevice = display.getHeight();

            fontPaint = new Paint();
            fontPaint.setStyle(Paint.Style.FILL);
            fontPaint.setColor(colorAccent);
            fontPaint.setTextSize(textScoreChap);

            if(WDevice<500) {
                textScoreChap = 12;
                fontPaint.setTextSize(textScoreChap);
            }

            WBlock = WDevice/(arenaCount+1);
            HBlock = (HDevice/(arenaCount+7));

            chapX = WBlock/2;
            chapY = HBlock/2;

            cmBScoreX = chapX;
            cmBScoreY = chapY;
            BSWidth = WDevice / 2;
            BSHeight = 2 * HBlock;

            WBackBtn = WBlock;
            HBackBtn = HBlock;

            cmSaveX = cmBScoreX + BSWidth + chapX;
            cmSaveY = cmBScoreY + HBlock;

            cmLoadX = cmSaveX + WBackBtn;
            cmLoadY = cmBScoreY + HBlock;

            cmHomeX = cmLoadX + WBackBtn;
            cmHomeY = cmBScoreY + HBlock;

            dx = chapX;
            dy = 2* chapY + BSHeight;

            cmKnopkaX = dx;
            cmKnopkaY = 3*chapY + BSHeight + arenaCount * HBlock;
            WKnopka = 2*WBlock;
            HKnopka = 2*HBlock;

            cmAfterBallY = chapY;

            cmKalabokX = 2*chapX + 6 * WBlock;
            cmKalabokY = 3*chapY + BSHeight + arenaCount * HBlock;
            WKalabok = 2*WBlock;
            HKalabok = 2*HBlock;

            cmScoreX = cmKnopkaX + WKnopka + chapX;
            cmScoreY = cmKnopkaY + textScoreChap;

            cmDownScoreX = cmScoreX;
            cmDownScoreY = cmKnopkaY + 2*textScoreChap;

            //matrixA = new int[64];
            matrixD = new String[arenaCount*arenaCount];
            matrixBC = new int[3];

            bitmapkalabok = new Bitmap[2];
            bitmapSourcekalabok = new Bitmap[2];
            bitmapknopka = new Bitmap[2];
            bitmapSourceknopka = new Bitmap[2];

            AfterBalls();

            bitmapMove = new Bitmap[2];
            bitmapSourceMove = new Bitmap[2];

            bitmapSourceBlock = BitmapFactory.decodeResource(getResources(), R.drawable.block);
            bitmapBlock = bitmapBlock.createScaledBitmap(bitmapSourceBlock, WBlock, HBlock, false);

            bitmapSourcekalabok[0] = BitmapFactory.decodeResource(getResources(), R.drawable.rkalabok);
            bitmapkalabok[0] = bitmapkalabok[0].createScaledBitmap(bitmapSourcekalabok[0], WKalabok, HKalabok, false);

            bitmapSourcekalabok[1] = BitmapFactory.decodeResource(getResources(), R.drawable.gkalabok);
            bitmapkalabok[1] = bitmapkalabok[1].createScaledBitmap(bitmapSourcekalabok[1], WKalabok, HKalabok, false);

            bitmapSourceknopka[0] = BitmapFactory.decodeResource(getResources(), R.drawable.csknopka);
            bitmapknopka[0] = bitmapknopka[0].createScaledBitmap(bitmapSourceknopka[0], WKnopka, HKnopka, false);

            bitmapSourceknopka[1] = BitmapFactory.decodeResource(getResources(), R.drawable.sknopka);
            bitmapknopka[1] = bitmapknopka[1].createScaledBitmap(bitmapSourceknopka[1], WKnopka, HKnopka, false);

            bitmapSourceBscore = BitmapFactory.decodeResource(getResources(), R.drawable.bscore1);
            bitmapBScore = bitmapBScore.createScaledBitmap(bitmapSourceBscore, BSWidth, BSHeight, false);

            bitmapSourceHome = BitmapFactory.decodeResource(getResources(), R.drawable.home);
            bitmapHome = bitmapSourceHome.createScaledBitmap(bitmapSourceHome, WBackBtn, HBackBtn, false);

            bitmapSourceSave = BitmapFactory.decodeResource(getResources(), R.drawable.save);
            bitmapSave = bitmapSourceSave.createScaledBitmap(bitmapSourceSave, WBackBtn, HBackBtn, false);

            bitmapSourceLoad = BitmapFactory.decodeResource(getResources(), R.drawable.load);
            bitmapLoad = bitmapSourceLoad.createScaledBitmap(bitmapSourceLoad, WBackBtn, HBackBtn, false);

            if(style) {
                bitmapSourceBlock = BitmapFactory.decodeResource(getResources(), R.drawable.block);
                bitmapBlock = bitmapSourceBlock.createScaledBitmap(bitmapSourceBlock, WBlock, HBlock, false);

                bitmapSource1 = BitmapFactory.decodeResource(getResources(), R.drawable.red);
                bitmap1 = bitmapSource1.createScaledBitmap(bitmapSource1, WBlock, HBlock, false);

                bitmapSource2 = BitmapFactory.decodeResource(getResources(), R.drawable.green);
                bitmap2 = bitmapSource2.createScaledBitmap(bitmapSource2, WBlock, HBlock, false);

                bitmapSource3 = BitmapFactory.decodeResource(getResources(), R.drawable.lblue);
                bitmap3 = bitmapSource3.createScaledBitmap(bitmapSource3, WBlock, HBlock, false);

                bitmapSource4 = BitmapFactory.decodeResource(getResources(), R.drawable.purple);
                bitmap4 = bitmapSource4.createScaledBitmap(bitmapSource4, WBlock, HBlock, false);

                bitmapSource5 = BitmapFactory.decodeResource(getResources(), R.drawable.yellow);
                bitmap5 = bitmapSource5.createScaledBitmap(bitmapSource5, WBlock, HBlock, false);

                bitmapSource6 = BitmapFactory.decodeResource(getResources(), R.drawable.blue);
                bitmap6 = bitmapSource6.createScaledBitmap(bitmapSource6, WBlock, HBlock, false);

                bitmapSource7 = BitmapFactory.decodeResource(getResources(), R.drawable.brown);
                bitmap7 = bitmapSource7.createScaledBitmap(bitmapSource7, WBlock, HBlock, false);
            }
            else{
                bitmapSourceBlock = BitmapFactory.decodeResource(getResources(), R.drawable.sblock);
                bitmapBlock = bitmapSourceBlock.createScaledBitmap(bitmapSourceBlock, WBlock, HBlock, false);

                bitmapSource1 = BitmapFactory.decodeResource(getResources(), R.drawable.sred);
                bitmap1 = bitmapSource1.createScaledBitmap(bitmapSource1, WBlock, HBlock, false);

                bitmapSource2 = BitmapFactory.decodeResource(getResources(), R.drawable.sgreen);
                bitmap2 = bitmapSource2.createScaledBitmap(bitmapSource2, WBlock, HBlock, false);

                bitmapSource3 = BitmapFactory.decodeResource(getResources(), R.drawable.slblue);
                bitmap3 = bitmapSource3.createScaledBitmap(bitmapSource3, WBlock, HBlock, false);

                bitmapSource4 = BitmapFactory.decodeResource(getResources(), R.drawable.spurple);
                bitmap4 = bitmapSource4.createScaledBitmap(bitmapSource4, WBlock, HBlock, false);

                bitmapSource5 = BitmapFactory.decodeResource(getResources(), R.drawable.syellow);
                bitmap5 = bitmapSource5.createScaledBitmap(bitmapSource5, WBlock, HBlock, false);

                bitmapSource6 = BitmapFactory.decodeResource(getResources(), R.drawable.sblue);
                bitmap6 = bitmapSource6.createScaledBitmap(bitmapSource6, WBlock, HBlock, false);

                bitmapSource7 = BitmapFactory.decodeResource(getResources(), R.drawable.sbrown);
                bitmap7 = bitmapSource7.createScaledBitmap(bitmapSource7, WBlock, HBlock, false);

                bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.scolormove);
                bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
            }

            gameArena = new int[arenaCount*arenaCount];
            setTimer();
            snulya();

        }

        void SaveGame() {

            SGame = "";

            for (int i = 0; i < arenaCount*arenaCount; i++) {
                SGame = SGame + String.valueOf(gameArena[i]);
            }
            SGame = SGame + Integer.valueOf(Score);
            SGame = SGame + "/" + NameUser;

            sPref = getPreferences(MODE_PRIVATE);
            SharedPreferences.Editor ed = sPref.edit();
            ed.putString(SAVED_TEXT, SGame);
            ed.commit();
        }

        void LoadGame() {
            sPref = getPreferences(MODE_PRIVATE);
            SGame = sPref.getString(SAVED_TEXT, "");
            posSkizb = -1;

            if (SGame == "") {
                Toast.makeText(PlayZone.this, "No Save!", Toast.LENGTH_SHORT).show();
                return;
            }

            for (int i = 0; i < arenaCount*arenaCount; i++) {
                gameArena[i] = Integer.valueOf(SGame.substring(i, i + 1));
            }
            Score = Integer.valueOf(SGame.substring(arenaCount*arenaCount, SGame.indexOf("/")));

        }

        private void setTimer() {
            if (tm != null)
                tm.cancel();
            tm = new Timer();
            myTimerTask = new MyTimerTask();
            tm.schedule(myTimerTask, 0, interval);
        }

        class MyTimerTask extends TimerTask {
            @Override
            public void run() {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        invalidate();

                        if(movment)
                            oneortwo();

                        if (ba) {
                            if (global == 0)
                                stanalchanaparh();

                            if (state == 0)
                                global++;

                            popox = matrixChanaparh[global];

                            if (popox == posHajord) {

                                ba = false;
                                gameArena[posHajord] = gameArena[posSkizb];
                                gameArena[posSkizb] = 0;
                                posSkizb = -1;

                                if (deleteLine()) {
                                    setball();
                                } else {
                                    gameArena[posHajord] = 0;
                                }

                                movment=false;

                            } else if (gameArena[posSkizb] != gameArena[popox]) {
                                gameArena[popox] = gameArena[posSkizb];
                                gameArena[posSkizb] = 0;
                                posSkizb = popox;
                            }

                        }
                    }
                });
            }
        }////

        public boolean onTouchEvent(MotionEvent event) {
            int x1, y1;


            if (event.getAction() == MotionEvent.ACTION_DOWN) {
                touchX = event.getX();
                touchY = event.getY();

                Rect rectKnopka = new Rect(cmKnopkaX, cmKnopkaY, cmKnopkaX + bitmapknopka[0].getWidth(),
                        cmKnopkaY + bitmapknopka[0].getHeight());

                Rect rectBScore = new Rect(cmBScoreX, cmBScoreY, cmBScoreX + bitmapBScore.getWidth(),
                        cmBScoreY + bitmapBScore.getHeight());

                Rect rectHome = new Rect(cmHomeX, cmHomeY, cmHomeX + bitmapHome.getWidth(),
                        cmHomeY + bitmapHome.getHeight());

                Rect rectSave = new Rect(cmSaveX, cmSaveY, cmSaveX + bitmapSave.getWidth(),
                        cmSaveY + bitmapSave.getHeight());

                Rect rectLoad = new Rect(cmLoadX, cmLoadY, cmLoadX + bitmapLoad.getWidth(),
                        cmLoadY + bitmapLoad.getHeight());

                if (rectHome.contains((int) touchX, (int) touchY)) {
                    Intent intent = new Intent(PlayZone.this, MainActivity.class);
                    finish();
                    startActivity(intent);
                    return true;
                }

                if (rectKnopka.contains((int) touchX, (int) touchY)) {
                    if (ba) ba = false;
                    BKnopka = false;
                    posSkizb = -1;
                    Score = 0;
                    snulya();
                    return true;
                }

                if (rectBScore.contains((int) touchX, (int) touchY)) {
                    Intent intent = new Intent(PlayZone.this, BestScore.class);
                    startActivity(intent);
                    return true;
                }

                if (rectSave.contains((int) touchX, (int) touchY)) {
                    SaveGame();
                    return true;
                }

                if (rectLoad.contains((int) touchX, (int) touchY)) {
                    LoadGame();
                    invalidate();
                    return true;
                }

                if (ba)
                    return true;

                x1 = (int) (touchX - dx) / WBlock;
                y1 = (int) (touchY - dy) / HBlock;

                posHajord = y1 * arenaCount + x1;

                if ((posHajord < 0 || posHajord > arenaCount*arenaCount-1) || (posSkizb == posHajord) || x1 >= arenaCount || y1 >= arenaCount || touchX - dx<0 || touchY - dy<0) {
                    posSkizb = -1;
                    return true;
                }

                /////////////////////
                if (gameArena[posHajord] != 0) {
                    posSkizb = posHajord;
                    SetMoveBallBitmap(posSkizb);
                    movment = true;
                    return true;
                }

                if (posSkizb == -1) return true;

                if (!stchanaparh()) {
                    BKalabok = false;
                    posSkizb = -1;
                    return true;
                }

                SetMoveBallBitmap(posSkizb);
                movment = true;
                global = 0;
                ba = true;



            }
            return true;
        }

        protected void stanalchanaparh() {
            String str1;

            str1 = matrixD[matrixCErkar];
            strerk = (int) (str1.length()) / 2;
            matrixChanaparh = new int[strerk];


            for (int i = 0; i < strerk; i++) {
                matrixChanaparh[i] = Integer.valueOf(str1.substring(i * 2, i * 2 + 2));
            }
        }

        @Override
        protected void onDraw(Canvas canvas) {

            canvas.drawRect(0, 0, WDevice, HDevice, paintBG);
            canvas.drawBitmap(bitmapHome, cmHomeX, cmHomeY, paint);
            canvas.drawBitmap(bitmapSave, cmSaveX, cmSaveY, null);
            canvas.drawBitmap(bitmapLoad, cmLoadX, cmLoadY, null);

            if (BKalabok)
                canvas.drawBitmap(bitmapkalabok[0], cmKalabokX, cmKalabokY, paint);
            else {
                canvas.drawBitmap(bitmapkalabok[1], cmKalabokX, cmKalabokY, paint);
                BKalabok = true;
            }

            if (BKnopka)
                canvas.drawBitmap(bitmapknopka[0], cmKnopkaX, cmKnopkaY, paint);
            else {
                canvas.drawBitmap(bitmapknopka[1], cmKnopkaX, cmKnopkaY, paint);
                BKnopka = true;
            }

            canvas.drawText("Score:" + String.valueOf(Score), cmScoreX, cmScoreY, fontPaint);
            canvas.drawText(String.valueOf(BSTvjal), cmDownScoreX, cmDownScoreY, fontPaint);

            cmAfterBallX = cmBScoreX + BSWidth + WBlock / 2;
            canvas.drawBitmap(bitmapBScore, cmBScoreX, cmBScoreY, paint);


            for (int i = 0; i < 3; i++) {
                switch (matrixBC[i]) {
                    case 1:
                        canvas.drawBitmap(bitmap1, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 2:
                        canvas.drawBitmap(bitmap2, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 3:
                        canvas.drawBitmap(bitmap3, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 4:
                        canvas.drawBitmap(bitmap4, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 5:
                        canvas.drawBitmap(bitmap5, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 6:
                        canvas.drawBitmap(bitmap6, cmAfterBallX, cmAfterBallY, paint);
                        break;
                    case 7:
                        canvas.drawBitmap(bitmap7, cmAfterBallX, cmAfterBallY, paint);
                        break;
                }
                cmAfterBallX = cmAfterBallX + WBlock;
            }

            for (int i = 0; i < arenaCount*arenaCount; i++) {

                y = (int) i / arenaCount;
                x = i - y * arenaCount;

                x = dx + x * WBlock;
                y = dy + y * HBlock;


                if (i != posSkizb) {
                    switch (gameArena[i]) {
                        case 0:
                            canvas.drawBitmap(bitmapBlock, x, y, paint);
                            break;
                        case 1:
                            canvas.drawBitmap(bitmap1, x, y, paint);
                            break;
                        case 2:
                            canvas.drawBitmap(bitmap2, x, y, paint);
                            break;
                        case 3:
                            canvas.drawBitmap(bitmap3, x, y, paint);
                            break;
                        case 4:
                            canvas.drawBitmap(bitmap4, x, y, paint);
                            break;
                        case 5:
                            canvas.drawBitmap(bitmap5, x, y, paint);
                            break;
                        case 6:
                            canvas.drawBitmap(bitmap6, x, y, paint);
                            break;
                        case 7:
                            canvas.drawBitmap(bitmap7, x, y, paint);
                            break;
                    }
                } else {
                        canvas.drawBitmap(bitmapMove[state], x, y, paint);
                }

            }
        }

        private void SetMoveBallBitmap(int nom){
            if(style) {
                switch (gameArena[nom]) {
                    case 1:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.red1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.red2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 2:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.green1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.green2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 3:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.lblue1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.lblue2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 4:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.purple1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.purple2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 5:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.yellow1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.yellow2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 6:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.blue1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.blue2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                    case 7:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.brown1);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);

                        bitmapSourceMove[1] = BitmapFactory.decodeResource(getResources(), R.drawable.brown2);
                        bitmapMove[1] = bitmapSourceMove[1].createScaledBitmap(bitmapSourceMove[1], WBlock, HBlock, false);
                        break;
                }
            }else{
                switch (gameArena[nom]) {
                    case 1:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.sred);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 2:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.sgreen);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 3:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.slblue);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 4:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.spurple);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 5:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.syellow);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 6:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.sblue);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                    case 7:
                        bitmapSourceMove[0] = BitmapFactory.decodeResource(getResources(), R.drawable.sbrown);
                        bitmapMove[0] = bitmapSourceMove[0].createScaledBitmap(bitmapSourceMove[0], WBlock, HBlock, false);
                        break;
                }
            }
        }


        private boolean deleteLine() {

            boolean c = true;
            int pos = posHajord;
            int deleteCount = 5;
            int ballColor = gameArena[pos];
            int curentCount = 1;

            int p1, p2;
            int bfPos = pos;

            //horizontal
            while (true) {
                if (pos % arenaCount == 0)
                    break;

                pos--;

                if (gameArena[pos] != ballColor) {
                    pos++;
                    break;
                }
                curentCount++;

            }

            p1 = pos;
            pos = bfPos;


            while (true) {
                if (pos % arenaCount == arenaCount - 1)
                    break;

                pos++;

                if (gameArena[pos] != ballColor) {
                    pos--;
                    break;
                }

                curentCount++;
            }

            p2 = pos;

            if (curentCount >= 5) {
                c = false;
                Score = Score + curentCount;
                for (int i = p1; i <= p2; i++) {
                    gameArena[i] = 0;
                }
            }

            //vertical
            pos = bfPos;
            curentCount = 1;

            while (true) {
                if (pos < arenaCount)
                    break;

                pos -= arenaCount;

                if (gameArena[pos] != ballColor) {
                    pos += arenaCount;
                    break;
                }

                curentCount++;

            }

            p1 = pos;
            pos = bfPos;

            while (true) {
                if (pos >= arenaCount * (arenaCount - 1))
                    break;

                pos += arenaCount;

                if (gameArena[pos] != ballColor) {
                    pos -= arenaCount;
                    break;
                }

                curentCount++;

            }

            p2 = pos;

            if (curentCount >= 5) {
                c = false;
                int skizb = p1 / arenaCount, verj = p2 / arenaCount, ps = p1;
                Score = Score + curentCount;
                for (int i = skizb; i <= verj; i++) {
                    gameArena[ps] = 0;
                    ps += arenaCount;
                }
            }

            //diagonal up down
            pos = bfPos;
            curentCount = 1;

            while (true) {
                if (pos % arenaCount == 0 || pos < arenaCount)
                    break;

                pos = pos - arenaCount - 1;

                if (gameArena[pos] != ballColor) {
                    pos = pos + arenaCount + 1;
                    break;
                }

                curentCount++;

            }

            p1 = pos;
            pos = bfPos;

            while (true) {
                if (pos % arenaCount == arenaCount - 1 || pos >= arenaCount * (arenaCount - 1))
                    break;

                pos = pos + arenaCount + 1;

                if (gameArena[pos] != ballColor) {
                    pos = pos - arenaCount - 1;
                    break;
                }

                curentCount++;
            }

            p2 = pos;

            if (curentCount >= 5) {
                c = false;
                int skizb = p1 / arenaCount, verj = p2 / arenaCount, ps = p1;
                Score = Score + curentCount;
                for (int i = skizb; i <= verj; i++) {
                    gameArena[ps] = 0;
                    ps =ps+ arenaCount + 1;
                }
            }

            //diagonal down up
            pos = bfPos;
            curentCount = 1;

            while (true) {
                if (pos % arenaCount == arenaCount - 1 || pos < arenaCount)
                    break;

                pos = pos - arenaCount + 1;

                if (gameArena[pos] != ballColor) {
                    pos = pos + arenaCount - 1;
                    break;
                }
                curentCount++;

            }

            p1 = pos;
            pos = bfPos;

            while (true) {
                if (pos % arenaCount == 0 || pos >= arenaCount * (arenaCount - 1))
                    break;

                pos = pos + arenaCount - 1;

                if (gameArena[pos] != ballColor) {
                    pos = pos - arenaCount + 1;
                    break;
                }
                curentCount++;

            }

            p2 = pos;

            if (curentCount >= 5) {
                c = false;
                int skizb = p1 / arenaCount, verj = p2 / arenaCount, ps = p1;
                Score = Score + curentCount;
                for (int i = skizb; i <= verj; i++) {
                    gameArena[ps] = 0;
                    ps =ps+ arenaCount - 1;
                }
            }

            return c;
        }

        protected void setball() {

            int pos1, j, col;
            int[] matrixB;
            matrixB = new int[arenaCount*arenaCount];

            col = 0;
            for (int i = 0; i < arenaCount*arenaCount; i++) {
                if (gameArena[i] == 0) {
                    matrixB[col] = i;
                    col++;
                }
            }

            col--;
            if (col < 3) {
                Intent intent = new Intent(PlayZone.this, BestScore.class);
                intent.putExtra("Score", String.valueOf(Score));
                startActivity(intent);
                snulya();
                return;
            }

            if(col>arenaCount*arenaCount-6){
                SharedPreferences prefs = getSharedPreferences(BestPlayer, MODE_PRIVATE);
                String name = prefs.getString("name", "No Best!");//"No name defined" is the default value.
                String score = prefs.getString("score", "");
                BSTvjal = name +":"+ score;
            }


            for (int i = 0; i < 3; i++) {
                pos1 = (int) (Math.random() * col);
                gameArena[matrixB[pos1]] = matrixBC[i];

                posHajord = matrixB[pos1];
                if (!deleteLine())
                    gameArena[posHajord] = 0;
                posHajord = -1;

                matrixB[pos1] = matrixB[col];
                col--;
            }

            AfterBalls();
        }

        protected void AfterBalls() {
            int guyn;
            for (int i = 0; i < 3; i++) {
                guyn = (int) (Math.random() * 7 + 1);
                matrixBC[i] = guyn;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        private boolean stchanaparh() {

            boolean b = true;

            matrixC = new int[arenaCount*arenaCount];
            matrixCErkar = 0;
            matrixC[0] = posSkizb;

            if (posSkizb >= 0 && posSkizb < 10)
                matrixD[0] = "0" + String.valueOf(posSkizb);
            else
                matrixD[0] = String.valueOf(posSkizb);

            for (int i = 0; i <= matrixCErkar; i++) {
                if (stugel(i))
                    return true;
            }
            return false;
        }

        private boolean isExit(int hamar) {
            for (int i = 0; i <= matrixCErkar; i++) {
                if (matrixC[i] == hamar) {
                    return true;
                }
            }
            return false;
        }

        private boolean AddToMatrixD(int hamar, int tvjalHamar) {
            String sPosHajord = String.valueOf(posHajord);
            if (sPosHajord.length() == 1)
                sPosHajord = "0" + sPosHajord;


            if (hamar == posHajord) {
                matrixD[matrixCErkar] = matrixD[tvjalHamar] + sPosHajord;
                return true;
            }
            if (gameArena[hamar] != 0 || isExit(hamar))
                return false;

            matrixCErkar++;
            matrixC[matrixCErkar] = hamar;
            if (hamar >= 0 && hamar < 10)
                matrixD[matrixCErkar] = matrixD[tvjalHamar] + "0" + matrixC[matrixCErkar];
            else
                matrixD[matrixCErkar] = matrixD[tvjalHamar] + matrixC[matrixCErkar];
            return false;
        }

        protected boolean stugel(int tvjalHamar) {

            int hamar = matrixC[tvjalHamar];
            int mnacord = hamar % arenaCount;

            for (int i = 0; i < 4; i++) {
                hamar = matrixC[tvjalHamar];
                switch (i) {
                    case 0:
                        if (hamar >= arenaCount) {
                            hamar = hamar - arenaCount;
                        }
                        break;
                    case 1:
                        if (hamar < arenaCount*(arenaCount-1)) {
                            hamar = hamar + arenaCount;
                        }
                        break;
                    case 2:
                        if (mnacord != 0) {
                            hamar = hamar - 1;
                        }
                        break;
                    case 3:
                        if (mnacord != arenaCount-1) {
                            hamar = hamar + 1;
                        }
                        break;
                }
                if (AddToMatrixD(hamar, tvjalHamar))
                    return true;
            }
            return false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void oneortwo() {
            state++;
            state=state%2;
        }

        private void snulya() {
            for (int i = 0; i < gameArena.length; i++)
                gameArena[i] = 0;
            Score = 0;
            setball();
        }

    }

}



