package com.unity3d.player;

import android.os.Bundle;
import android.util.Log;

public class TestOverrideActivity extends UnityPlayerActivity{

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        Log.d("cafe.game","onCreate:TestOverride");
    }

    @Override
    protected void onStart()
    {
        super.onStart();
        Log.d(  "cafe.game", "onStart:TestOverride");
    }
    @Override
    protected void onPause()
    {
        super.onPause();
        Log.d(  "cafe.game", "onPause:TestOverride");
    }
    @Override
    protected void onResume()
    {
        super.onResume();
        Log.d(  "cafe.game", "onResume:TestOverride");
    }
    @Override
    protected void onStop()
    {
        super.onStop();
        Log.d(  "cafe.game", "onStop:TestOverride");
    }
    @Override
    protected void onDestroy()
    {
        Log.d(  "cafe.game", "onDestroy:TestOverride");
        super.onDestroy();
    }
}
