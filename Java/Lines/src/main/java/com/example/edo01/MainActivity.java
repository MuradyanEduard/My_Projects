package com.example.edo01;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ScrollView;


public class MainActivity extends AppCompatActivity {

    String prefName ="ColorDesign";
    SharedPreferences.Editor editor;

    LinearLayout mPanel;

    Bitmap bitmap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportActionBar().hide();

        mPanel = findViewById(R.id.mainPanel);

        Button btnStart = findViewById(R.id.btnStart);
        btnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this, PlayZone.class);
                finish();
                startActivity(intent);
            }
        });

        Button btnExit = findViewById(R.id.btnExit);
        btnExit.setOnClickListener(new View.OnClickListener() {
            @SuppressLint("NewApi")
            @Override
            public void onClick(View view) {
                finish();
                System.exit(0);
            }
        });

        Button btnOptions = findViewById(R.id.btnOptions);
        btnOptions.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View view) {
                Intent intent = new Intent(MainActivity.this, Options.class);
                finish();
                startActivity(intent);
            }
        });

        Button btnHowToPlay = findViewById(R.id.btnHowToPlay);
        btnHowToPlay.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View view) {
                Intent intent = new Intent(MainActivity.this, HowToPlay.class);
                startActivity(intent);
            }
        });

        SharedPreferences prefs = getSharedPreferences(prefName, MODE_PRIVATE);
        int red = prefs.getInt("red", (int)255);
        int green = prefs.getInt("green", (int)255);
        int blue = prefs.getInt("blue", (int)0);

        int colorMain = Color.rgb(red,green,blue);
        int colorAccent = Color.rgb(255-red,255-green,255-blue);

        mPanel.setBackgroundColor(colorMain);
        btnStart.setBackgroundColor(colorAccent);
        btnStart.setTextColor(colorMain);
        btnOptions.setBackgroundColor(colorAccent);
        btnOptions.setTextColor(colorMain);
        btnHowToPlay.setBackgroundColor(colorAccent);
        btnHowToPlay.setTextColor(colorMain);
        btnExit.setBackgroundColor(colorAccent);
        btnExit.setTextColor(colorMain);


    }

}
