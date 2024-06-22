const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('login button test',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../login.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'../Login.js'),'utf8');

    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('username').value="shrish";
    dom.window.document.getElementById('password').value="123";
    dom.window.document.getElementById('login-button').click();

    const actual = dom.window.document.getElementById('result').innerText;
    expect(actual).toBe('Login Successfull');
});

test('login button test',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../login.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'../Login.js'),'utf8');

    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('username').value="somethin";
    dom.window.document.getElementById('password').value="123";
    dom.window.document.getElementById('login-button').click();

    const actual = dom.window.document.getElementById('result').innerText;
    expect(actual).toBe('Login Failed');
});