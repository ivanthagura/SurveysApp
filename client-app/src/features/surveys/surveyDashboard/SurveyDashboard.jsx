import React from 'react';
import { Grid } from 'semantic-ui-react';
import SurveyList from './SurveyList';
import { surveysData } from '../../../app/api/sampleData';

export default function SurveyDashboard() {
    return (
        <Grid>
            <Grid.Column width={16}>
                <SurveyList surveys ={surveysData}/>
            </Grid.Column>
        </Grid>
    );
}