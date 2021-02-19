import React, {useState, useEffect} from 'react';
import SurveyForm from '../surveyForm/SurveyForm';
import agent from '../../../app/api/agent';
import { useHistory } from 'react-router-dom'

export default function SurveyDetailedPage({match}) {
    const history = useHistory();
    const [survey, setSurvey] =  useState({name: 'Survey not found'});

    const getSurvey = async () => {
        try {
            const surveyResponse = await agent.Surveys.details(match.params.id);
            setSurvey(surveyResponse);
        }
        catch(reponse) {
            history.push('/notfound');
        }
    };

    useEffect(() => {
        getSurvey();
    }, []);

    return (
        <>
            <h1>{survey.name}</h1>
            <SurveyForm survey={survey} />
        </>
    );
}