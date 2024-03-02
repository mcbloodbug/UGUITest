package com.unity3d.player;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
public class TestActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        //设置布局
        setContentView(R.layout.first_layout);
        //找到button组件的对象，根据id
        Button btn =findViewById(R.id.btn01);

        //给按钮加上监听事件
        btn.setOnClickListener(new View.OnClickListener(){
            @Override
        public void onClick (View v)
        {
            //创建一个从当前场景(TestActivity) 跳转到unity场景(UnityPlayerActivity)的事件
            Intent intent = new Intent(TestActivity.this, TestOverrideActivity.class);
            startActivity(intent);
        }
    });
    }
}