
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Patient from './Component/Patient';
import { Provider } from 'react-redux';
import compstore from './Redux/Store';
import { ToastContainer } from 'react-toastify';

function App() {
  return (
    <Provider store={compstore}>
    <BrowserRouter>

      <Routes>
       <Route path='/' element={<Patient></Patient>}></Route>
      </Routes>
    </BrowserRouter>
    <ToastContainer position='top-right'></ToastContainer>
    </Provider>
  );
}

export default App;
