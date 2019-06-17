﻿var Language = {
    //公共提示
    common: {
        refresh: "刷新",
        fold: "折叠",
        unfold: "展开",
        wait: "正在努力处理中,请稍等...",
        deletemsg: "删除后不可恢复,确认删除选中信息?",
        addagain: "操作成功,确定继续新增?",
        ajaxposterror: "数据请求出错,请联系管理员",
        guidempty: "00000000-0000-0000-0000-000000000000"
    },

    //登录提示
    login: {
        noname: "请录入用户名",
        nopwd: "请输入密码",
        nocode: "请输入验证码",
        loginwait: "正在登录中,请稍等..."
    },

    //主界面提示
    console: {
        leave: "离开后可能会导致数据丢失？",
        loginout: "确认退出?退出后系统将跳转至登录界面。"
    },

    //配置项提示
    system: {
        resetPassword: "确定重置密码?"
    },

    //权限类型
    privilegeMaster: {
        role: 0,//角色
        organization: 1,//组织机构
        group: 2,//组
        post: 3,//岗位
        user: 4//用户
    },

    //权限归属
    privilegeAccess: {
        menu: 0,//菜单
        func: 1,//模块按钮
        field: 2,//字段
        data: 3//数据
    },

    //菜单类型
    menuType: {
        haveMenuPermission: 0,//具有菜单权限
        haveDataPermission: 2,//具有数据权限
        haveFieldPermission: 4,//具有字段权限
        haveFunctionPermission: 6,//具有模块按钮权限
        isFreeze: 8,//是否冻结
        isShowMenu: 10//是否显示到菜单
    },

    //工作流提示
    workflow: {

    }
}