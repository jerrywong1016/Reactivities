import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { ducks } from './demo';
// import Duckitem from './Duckitem';
import axios from 'axios';
import {Header, List} from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  },[])

  return (
    <div>
      <Header as= 'h2' icon='users' content='Reactivities'/>
        <List>
          <List.Item>
            {activities.map((activity: any) =>(
              <li key={activity.id}>{activity.title}</li>
            ))}
          </List.Item>
        </List>
      <header className="App-header">
        {/* {ducks.map(duck => (
          // when looping an array, make sure give each on e a key
          <Duckitem duck={duck} key={duck.name}/>
        ))} */}
      </header>
    </div>
  );
}

export default App;
