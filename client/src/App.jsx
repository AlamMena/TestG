import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import LogTable from './table';

function App() {
  const [inputText, setInputText] = useState('');
  const [apiResult, setApiResult] = useState('');
  const [logs, setLogs] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  const handleInputChange = (event) => {
    setInputText(event.target.value);
  };

  useEffect(() => {
    // Aquí debes realizar una solicitud a tu API para obtener los datos de registro.
    // Puedes utilizar la función fetch o una biblioteca como axios.
    // Reemplaza la URL con la de tu API.
    fetch(import.meta.env.VITE_BASE_URL+'/api/Logs')
      .then((response) => response.json())
      .then((data) => setLogs(data))
      .catch((error) => console.error('Error al cargar los datos', error));
  }, [isLoading]);

  const handleApiCall = () => {
    setIsLoading(true);

    // Replace 'YOUR_API_ENDPOINT' with the actual API endpoint
    fetch(import.meta.env.VITE_BASE_URL+'/api/Algorithms/pattern', {
      method: 'POST',
      body: JSON.stringify({ phrase: inputText , requestDate: new Date(), user:991}),
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((response) => response.json())
      .then((data) => {
        setApiResult(data.pattern);
        setIsLoading(false);
      })
      .catch((error) => {
        console.error('Error:', error);
        setIsLoading(false);
      });
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">API Call Screen</h1>

      <div className="flex mb-4">
        <input
          type="text"
          className="border p-2 flex-1"
          placeholder="Enter a string"
          value={inputText}
          onChange={handleInputChange}
        />
        <button
          className="bg-blue-500 text-white p-2 ml-2"
          onClick={handleApiCall}
          disabled={isLoading}
        >
          {isLoading ? 'Loading...' : 'Call API'}
        </button>
      </div>

      <div className="border-dashed border-2 border-gray-300 p-4">
        <h2 className="text-lg font-semibold mb-2">API Result:</h2>
        <div className="break-all">{apiResult}</div>
      </div>
      <LogTable logs={logs}/>
    </div>
  );
}
export default App
