package com.example.edo01;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

public class BestScore extends AppCompatActivity {

    String prefName ="ColorDesign";

    SharedPreferences sPref;
    String BSName = "";

    final String SAVED_TEXT = "saved_text";
    final String BestPlayer = "best";
    //String[][] BSBase;
    String Firstx;
    boolean t = true;
    TextView[] textView = new TextView[10];
    BSList[] bsLists = new BSList[10];

    Resources res;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_best_score);


        SharedPreferences dpref = getSharedPreferences(prefName, MODE_PRIVATE);
        int red = dpref.getInt("red", (int)255);
        int green = dpref.getInt("green", (int)255);
        int blue = dpref.getInt("blue", (int)0);

        int colorMain = Color.rgb(red,green,blue);
        int colorAccent = Color.rgb(255-red,255-green,255-blue);

        res = getResources();

        LinearLayout ln = findViewById(R.id.mainPanel);
        ln.setBackgroundColor(colorMain);

        TextView tvbg = findViewById(R.id.textViewBestScore);
        tvbg.setTextColor(colorAccent);

        getSupportActionBar().hide();

        Button btnUpdate = findViewById(R.id.btnUpdate);
        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(getBaseContext(), "Click!" , Toast.LENGTH_SHORT ).show();
            }
        });

        Button btnGetBack = findViewById(R.id.btnGetBack);
        btnGetBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        Button btnClean = findViewById(R.id.btnClean);
        btnClean.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences.Editor editor = getSharedPreferences(BestPlayer, MODE_PRIVATE).edit();
                editor.putString("name", "");
                editor.putString("score", "");
                editor.apply();

                BSName = " /0! /0! /0! /0! /0! /0! /0! /0! /0! /0!";
                saveText();
                Intent intentAgain = getIntent();
                finish();
                startActivity(intentAgain);
            }
        });

        btnGetBack.setBackgroundColor(colorAccent);
        btnGetBack.setTextColor(colorMain);
        btnClean.setBackgroundColor(colorAccent);
        btnClean.setTextColor(colorMain);
        btnUpdate.setBackgroundColor(colorAccent);
        btnUpdate.setTextColor(colorMain);

        loadText();

        for (int i = 0;i<textView.length;i++){
            String str = "textView" + (i+1);
            textView[i] = findViewById(res.getIdentifier(str, "id", getPackageName()));
            textView[i].setTextColor(colorAccent);
        }


        String[] topList = BSName.split("!");

        for(int i=0;i<topList.length;i++){
            String[] strArr = topList[i].split("/");
            bsLists[i] = new BSList();
            bsLists[i].setName(strArr[0]);
            bsLists[i].setScore(Integer.valueOf(strArr[1]));
        }


        String NBScore,Name, Hamar;

        Intent intentRG = getIntent();
        Name = intentRG.getStringExtra("Name");
        Hamar = intentRG.getStringExtra("Hamar");
        NBScore = intentRG.getStringExtra("Score");

        if (Name == null && Hamar == null && NBScore == null) {
            Best10();
            return;
        }

        if (Name == null) {
            for (int i = 0; i < 9; i++) {
                t=false;
                if (Integer.valueOf(NBScore) > bsLists[i].getScore()) {
                    Intent intentPZ = new Intent(this, Reg.class);
                    intentPZ.putExtra("Hamar", String.valueOf(i));
                    intentPZ.putExtra("Score", NBScore);
                    finish();
                    startActivity(intentPZ);
                    return;
                }
            }
        }

        if(!t) {
            Best10();
            return;
        }

        String n1, n2;
        int s1,s2;

        n1 = bsLists[Integer.valueOf(Hamar)].getName();
        s1 = bsLists[Integer.valueOf(Hamar)].getScore();
        bsLists[Integer.valueOf(Hamar)].setName(Name);
        bsLists[Integer.valueOf(Hamar)].setScore(Integer.valueOf(NBScore));

        for (int i = Integer.valueOf(Hamar) + 1; i < 10; i++) {
            n2 = bsLists[i].getName();
            s2 = bsLists[i].getScore();

            bsLists[i].setName(n1);
            bsLists[i].setScore(s1);
            n1 = n2;
            s1 = s2;
        }

        Best10();
        saveText();

        SharedPreferences.Editor editor = getSharedPreferences(BestPlayer, MODE_PRIVATE).edit();
        editor.putString("name", bsLists[0].getName());
        editor.putString("score", Integer.toString(bsLists[0].getScore()));
        editor.apply();
    }


    void Best10() {
        BSName = "";

        for(int i=0;i<bsLists.length;i++)
            BSName += bsLists[i].getName() + "/" + bsLists[i].getScore() + "!";

        for(int i=0;i<bsLists.length;i++)
            textView[i].setText((i+1)+ " " + bsLists[i].getName() + " " + bsLists[i].getScore());
    }

    void saveText() {
        sPref = getPreferences(MODE_PRIVATE);
        SharedPreferences.Editor ed1 = sPref.edit();
        ed1.putString(SAVED_TEXT, BSName);
        ed1.commit();
    }

    void loadText() {
        sPref = getPreferences(MODE_PRIVATE);
        BSName = sPref.getString(SAVED_TEXT, " /0! /0! /0! /0! /0! /0! /0! /0! /0! /0!");
    }
}
