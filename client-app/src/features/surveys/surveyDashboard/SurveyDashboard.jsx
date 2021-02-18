import React, { useState, useEffect }  from 'react';
import { Grid } from 'semantic-ui-react';
import SurveyList from './SurveyList';
import agent from '../../../app/api/agent';

export default function SurveyDashboard() {
    const [surveys, setSurveys] =  useState([]);

    const getSurveys = async () => {
        const surveysResponse = await agent.Surveys.list();
        setSurveys(surveysResponse);
    };

    useEffect(() => {
        getSurveys();
    }, []);

    return (
        <Grid>
            <Grid.Column width={16}>
                <SurveyList surveys ={surveys}/>
            </Grid.Column>
        </Grid>
    );
}