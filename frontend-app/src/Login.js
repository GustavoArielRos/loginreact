import React, { Fragment, useState } from 'react'; // importa o react e os dois hooks
import axios from "axios";//importa o axios para fazer as requisições http

function Login(){
    //declara os estado para serem usados no componente
    const [name, setName] = useState('');
    const [phoneNo, setPhoneNo] = useState('');

    //declara as funções que alteram o valor dos estados
    const handleNameChange = (value) => {
        setName(value);
      };
      const handlePhoneNOChange = (value) => {
        setPhoneNo(value);
      };
    
    //função que gera o login
    const handleLogin = () => {
        //objeto criado no qual seus atributos possuem os valores sendo os estados desse componete
        const data = {
            Name : name,
            PhoneNo : phoneNo,
        };
        //caminho dessa API
        const url = 'https://localhost:44304/api/Test/Login';

        //usando o axios para fazer a requisição
        //perceba que ele faz uma requisição post para o caminho "url", enviando no corpo da requisição o "data"
        axios.post(url,data).then((result) => { //se der certo recebe uma resposta
            if(result.data == 'Data inserted.')
                alert('data saved');
            else
            {
                alert(result.data);
            }
        }).catch((error) => {//deu errado
         alert(error);   
        })
    };

    return(
        <Fragment>
            <label>Name</label>
            <input 
              type="text" 
              id="txtName" 
              placeholder="Enter Name" 
              onChange={(e) => handleNameChange(e.target.value)} 
            />
            <br></br>
            <label>Phone No</label>
            <input type="text" id="txtPhoneNo" placeholder="Enter Phone No" onChange={(e) => handlePhoneNOChange(e.target.value)}  /><br></br>
            <button onClick={() => handleLogin()}>Login</button>
        </Fragment>
    )
}


export default Login;