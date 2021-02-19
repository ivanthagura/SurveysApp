import React from 'react';
import { Route } from 'react-router-dom';
import { Container } from 'semantic-ui-react';
import HomePage from '../../features/home/HomePage';
import NavBar from '../../features/nav/NavBar';
import SurveyDashboard from '../../features/surveys/surveyDashboard/SurveyDashboard';
import SurveyDetailedPage from '../../features/surveys/surveyDetailed/SurveyDetailedPage';
import NotFoundPage from './NotFoundPage';
import { Toaster } from 'react-hot-toast';

export default function App() {
  return (
    <>
      <Route exact path='/' component={HomePage} />
      <Route path={'/(.+)'} render={() => (
        <>
          <Toaster />
          <NavBar/>
          <Container className='main'>
            <Route exact path='/surveys' component={SurveyDashboard} />
            <Route path='/surveys/:id' component={SurveyDetailedPage} />
            <Route path='/notfound' component={NotFoundPage} />
          </Container>
        </>
      )} />
    </>
  );
}
