import React, {useState} from 'react';
import { Button, Form, Header, Segment } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import toast from 'react-hot-toast';
import agent from '../../../app/api/agent';
import { useHistory } from 'react-router-dom';

export default function SurveyForm({survey}) {
    const history = useHistory();
    const { id, name, questions } = survey;
    const [userName, setUserName] = useState('');
    const [userEmail, setUserEmail] = useState('');
    const [answers, setAnswers] = useState(questions.map(question => (
        {
            questionId: question.id,
            questionAnswer: ''
        }
    )));

    const submitSurvey = async (survey) => {
        try {
            const response = await agent.Surveys.submit(survey);
            if(response === 200)
            {
                toast('Survey successfully submitted. Thank you', {
                    icon: '👏',
                  });
                history.push('/surveys');
            }
        }
        catch(reponse) {
            history.push('/surveys');
        }
    };

    function handleFormSubmit(e) {
        e.preventDefault();
        const submittedAnswers = answers.filter(a => a.questionAnswer !== '')
        if(submittedAnswers.length > 0) {
            const requestBody = {
                name: userName,
                email: userEmail,
                surveyId: id,
                answers: submittedAnswers
            }

            submitSurvey(requestBody);
        }
        else {
            toast.error('Please answer at least one question');
        }
    }

    function handleUserNameChange(e)
    {
        setUserName(e.target.value);
    }

    function handleUserEmailChange(e)
    {
        setUserEmail(e.target.value);
    }

    function handleInputChangeRadio(e, { value }) {
        const result = value.split('_');
        const selectedQuestionId = parseInt(result[0]);
        const selectedAnswer = result[1];
        const newAnswer = {
            questionId: selectedQuestionId,
            questionAnswer: selectedAnswer
        }
        setAnswers([...answers.filter(a => a.questionId !== selectedQuestionId), newAnswer]);
    }

    return (
        <Segment clearing>
            <Header content={name} />
            <Form onSubmit={handleFormSubmit}>
                <Form.Input label='Name' placeholder='Name' value={userName} onChange={handleUserNameChange} />
                <Form.Input 
                    type='email'
                    label='Email' 
                    placeholder='Email' 
                    value={userEmail} 
                    onChange={handleUserEmailChange}
                />
                {questions.map(question => (
                    <Form.Group grouped key={question.id}>
                        <label>{question.title}</label>
                        {question.options.map(option => (
                            <Form.Radio 
                                key={option.id}
                                label={option.text}
                                value={`${question.id}_${option.text}`}
                                checked={answers.find(a => a.questionId === question.id).questionAnswer === option.text}
                                onChange={handleInputChangeRadio}
                            />
                        ))}
                    </Form.Group>
                ))}
                <Button type='submit' floated='right' positive content='Submit' />
                <Button as={Link} to={'/surveys'} type='submit' floated='right' positive content='Cancel' />
            </Form>
        </Segment>
    );
}