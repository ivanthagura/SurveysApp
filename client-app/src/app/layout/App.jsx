import React from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from '../../features/nav/NavBar';
import SurveyDashboard from '../../features/surveys/surveyDashboard/SurveyDashboard';

export default function App() {
  return (
    <>
      <NavBar/>
      <Container className='main'>
        <SurveyDashboard />
      </Container>
    </>
  );
}
