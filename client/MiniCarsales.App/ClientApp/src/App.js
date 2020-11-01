import React, { memo } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Container } from 'reactstrap';
import Home from './pages/home';
import Car from './pages/car';
import NotFound from './pages/not-found';

export default memo(() => {
  return (
    <Container className="mt-5">
      <BrowserRouter>
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/car" component={Car} />
          <Route component={NotFound} />
        </Switch>
      </BrowserRouter>
    </Container>
  );
});
