import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { useState } from 'react';

function App() {
  const [array, setArray] = useState("");
  const [result, setResult] = useState("");
  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const resp = await axios.post('https://localhost:5001/stepmedia-interview', array, {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        }
      }
      );
      setResult(resp.data);
    } catch (err) {
      setResult(err.response.data);
    }
  }
  return (
    <div className="App">
      <header className="App-header">
        <form onSubmit={handleSubmit}>
          <h1>Enter your array:</h1>
            <input
              type="text"
              value={array}
              onChange={(e) => setArray(e.target.value)}
            />
            <br />
          <input type="submit" />
        </form>
        <h5>Result</h5>
        <h6>{result}</h6>
      </header>
    </div>
  );
}

export default App;
