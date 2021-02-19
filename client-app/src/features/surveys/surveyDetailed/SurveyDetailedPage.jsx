import React, {useState, useEffect} from 'react';
import SurveyForm from '../surveyForm/SurveyForm';
import agent from '../../../app/api/agent';

export default function SurveyDetailedPage({match}) {
    const [survey, setSurvey] =  useState({name: 'test'});

    const getSurvey = async () => {
        const surveyResponse = await agent.Surveys.details(match.params.id);
        setSurvey(surveyResponse);
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