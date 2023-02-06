package com.example.edo01;

import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import static android.icu.lang.UCharacter.toUpperCase;

public class Reg extends AppCompatActivity {

    EditText etText;
    Button btnReg;
    String SaveName = "", Hamar, Score;
    String prefName ="ColorDesign";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reg);

        getSupportActionBar().hide();

        etText = (EditText) findViewById(R.id.etText);
        btnReg = (Button) findViewById(R.id.RegButton);

        SharedPreferences prefs = getSharedPreferences(prefName, MODE_PRIVATE);
        int red = prefs.getInt("red", (int)255);
        int green = prefs.getInt("green", (int)255);
        int blue = prefs.getInt("blue", (int)0);

        int colorMain = Color.rgb(red,green,blue);
        int colorAccent = Color.rgb(255-red,255-green,255-blue);

        LinearLayout ln = findViewById(R.id.mainPanel);
        ln.setBackgroundColor(colorMain);
        TextView txt =  findViewById(R.id.textView1);
        txt.setTextColor(colorAccent);
        txt = findViewById(R.id.textView2);
        txt.setTextColor(colorAccent);
        etText.setTextColor(colorAccent);
        btnReg.setBackgroundColor(colorAccent);
        btnReg.setTextColor(colorMain);
    }

    public void onClick3(View v) {
        SaveName = etText.getText().toString();
        if(SaveName.length() > 16)
        {
            Toast.makeText(Reg.this, "Nickname must be max 16 symballs!", Toast.LENGTH_SHORT).show();
        }
        if (SaveName.matches("[a-zA-Z0-9][a-zA-Z0-9\\-]{0,64}")) {
            Intent intentRG = getIntent();
            Hamar = intentRG.getStringExtra("Hamar");
            Score = intentRG.getStringExtra("Score");

            Intent intent = new Intent(this, BestScore.class);
            intent.putExtra("Name", SaveName);
            intent.putExtra("Hamar", Hamar);
            intent.putExtra("Score", Score);
            finish();
            startActivity(intent);

        } else
            Toast.makeText(Reg.this, "The string contains extra characters!", Toast.LENGTH_SHORT).show();

    }
}