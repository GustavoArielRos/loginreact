
/*COMPONENTE PRINCIPAL DA APLICAÇÃO */

import './App.css';//css do componente
import Registration from './Registration'; //componente de registro
import Login from './Login'; //componente de login

//componente desse arquivo 
function App() {

  //return (permite escrever o html dentro do javacripst)
  return (
    <div className="App">
      {/*renderiza o componente de registro importado */}
      <Registration /><br></br>
      <br>
      </br>
      {/*renderiza o componente de login importado */}
      <Login />
    </div>
  );
}

export default App;// dessa forma eu consigo importa esse componente
