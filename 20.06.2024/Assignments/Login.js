function login(){
    // console.log("Hello World!!")
    const username=document.getElementById("username").value;
    const password=document.getElementById("password").value;
    // console.log(username);
    // console.log(password);
    const validUsername=["shrish","naresh"];
    const validPassword=["123","456"];

    let isValid = false;
    for (let i = 0; i < validUsername.length; i++) 
    {
        if (username === validUsername[i] && password === validPassword[i]) 
        {
            isValid = true;
            break;
        }
    }

    if(isValid){
        document.getElementById("result").innerText="Login Successfull";
    }
    else{
        document.getElementById("result").innerText ="Login Failed";
    }

}