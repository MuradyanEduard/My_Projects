package com.example.edo01;

import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ScrollView;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

public class Options extends AppCompatActivity {

    boolean style = true;
    int amSpeed = 0;

    String prefName = "ColorDesign";
    SharedPreferences.Editor editor;

    SeekBar[] seekBar;
    TextView[] textView;

    ScrollView mPanel;
    int[] rgb;

    RadioButton[] rb;
    Button btnSave,btnGetback;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_options);
        getSupportActionBar().hide();

        seekBar = new SeekBar[3];
        textView = new TextView[3];
        rgb = new int[3];

        SharedPreferences prefs = getSharedPreferences(prefName, MODE_PRIVATE);
        rgb[0] = prefs.getInt("red", (int)255);
        rgb[1] = prefs.getInt("green", (int)255);
        rgb[2] = prefs.getInt("blue", (int)0);
        style = prefs.getBoolean("style", (boolean) true);
        amSpeed = prefs.getInt("speed", (int) 2);

        RadioGroup radioGroup = (RadioGroup) findViewById(R.id.groupradio);

        if(style){
            radioGroup.check(R.id.radia_id1);
        }else {
            radioGroup.check(R.id.radia_id2);
        }

        radioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener()
        {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                style = !style;
            }
        });

        RadioGroup spRadioGroup = (RadioGroup) findViewById(R.id.radiospeed);
        rb = new RadioButton[3];

        rb[0] = findViewById(R.id.rd1);
        rb[1] = findViewById(R.id.rd2);
        rb[2] = findViewById(R.id.rd3);

        switch (amSpeed){
            case 0:
                rb[0].setChecked(true);
                break;
            case 1:
                rb[1].setChecked(true);
                break;
            case 2:
                rb[2].setChecked(true);
                break;
        }
        spRadioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener()
        {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                if(rb[0].isChecked())
                    amSpeed = 0;
                else if(rb[1].isChecked())
                    amSpeed = 1;
                else
                    amSpeed = 2;
               // Toast.makeText(getBaseContext(),  checkedId + "", Toast.LENGTH_LONG).show();
            }
        });

        mPanel = findViewById(R.id.mainPanel);

        btnSave = findViewById(R.id.btnSave);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setConfig();
            }
        });

        btnGetback = findViewById(R.id.btnGetBack);

        seekBar[0] = (SeekBar) findViewById(R.id.sBRed);
        seekBar[1] = (SeekBar) findViewById(R.id.sBGreen);
        seekBar[2] = (SeekBar) findViewById(R.id.sBBlue);

        int rc = rgb[0]
                ,gc = rgb[1]
                ,bc = rgb[2];

        seekBar[0].setProgress(rc);
        seekBar[1].setProgress(gc);
        seekBar[2].setProgress(bc);

        textView[0] = (TextView) findViewById(R.id.txtView1);
        textView[0].setText(String.valueOf(rc));
        textView[1] = (TextView) findViewById(R.id.txtView2);
        textView[1].setText(String.valueOf(gc));
        textView[2] = (TextView) findViewById(R.id.txtView3);
        textView[2].setText(String.valueOf(bc));

        seekBar[0].setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {

                textView[0].setText(String.valueOf(progress));
                rgb[0] = progress;
                setDesign();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });
        seekBar[1].setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                textView[1].setText(String.valueOf(progress));
                rgb[1] = progress;
                setDesign();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });
        seekBar[2].setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                textView[2].setText(String.valueOf(progress));
                rgb[2] = progress;
                setDesign();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        Button btnGetBack = findViewById(R.id.btnGetBack);
        btnGetBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Options.this, MainActivity.class);
                finish();
                startActivity(intent);
            }
        });
        setDesign();
    }

    private void setDesign(){

        int colorMain,colorAccent;

        SharedPreferences prefs = getSharedPreferences(prefName, MODE_PRIVATE);
        int red = prefs.getInt("red", (int)255);
        int green = prefs.getInt("green", (int)255);
        int blue = prefs.getInt("blue", (int)255);

        colorMain = Color.rgb(rgb[0],rgb[1],rgb[2]);
        colorAccent = Color.rgb(255-rgb[0],255-rgb[1],255-rgb[2]);

        mPanel.setBackgroundColor(colorMain);

        btnSave.setBackgroundColor(colorAccent);
        btnSave.setTextColor(colorMain);

        btnGetback.setBackgroundColor(colorAccent);
        btnGetback.setTextColor(colorMain);

        TextView scTextView = findViewById(R.id.scTextView1);
        scTextView.setTextColor(colorMain);

        scTextView = findViewById(R.id.scTextView2);
        scTextView.setTextColor(colorMain);

        TextView tv = findViewById(R.id.scTextView3);
        tv.setTextColor(colorMain);

        rb[0].setTextColor(colorMain);
        rb[1].setTextColor(colorMain);
        rb[2].setTextColor(colorMain);

    }

    private void setConfig(){
        editor = getSharedPreferences(prefName, MODE_PRIVATE).edit();
        editor.putInt("red", rgb[0]);
        editor.putInt("green", rgb[1]);
        editor.putInt("blue", rgb[2]);
        editor.putBoolean("style",style);
        editor.putInt("speed",amSpeed);
        editor.putInt("txtSize", 14);
        editor.apply();
    }

}
